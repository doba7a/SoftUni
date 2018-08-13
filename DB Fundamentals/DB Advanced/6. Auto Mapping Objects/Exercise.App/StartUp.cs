namespace Exercise.App
{
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    using System;
    using Exercise.App.Profiles;
    using Exercise.Core;
    using Exercise.Data;
    using Exercise.Services;
    using Exercise.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider sp = ConfigureServices();

            Engine engine = new Engine(sp);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddDbContext<ExerciseContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Production"), b => b.MigrationsAssembly("Forum.App")));

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();
            serviceCollection.AddTransient<IWriter, Writer>();
            serviceCollection.AddTransient<IReader, Reader>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            return serviceCollection.BuildServiceProvider();
        }
    }
}
