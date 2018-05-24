using System;
using Microsoft.Extensions.DependencyInjection;

public class StartUp
{
    public static void Main()
    {
        IServiceProvider serviceProvider = ConfigureServices();

        CommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        Engine engine = new Engine(commandInterpreter);

        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<IWeaponFactory, WeaponFactory>();
        services.AddTransient<IGemFactory, GemFactory>();

        services.AddSingleton<IRepository, WeaponRepository>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}

