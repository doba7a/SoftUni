using Microsoft.Extensions.DependencyInjection;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureServices();

        ICommandInterpreter commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();
        IReader reader = serviceProvider.GetService<IReader>();
        IWriter writer = serviceProvider.GetService<IWriter>();

        Engine engine = new Engine(commandInterpreter, reader, writer);

        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IWriter, Writer>();
        serviceCollection.AddTransient<IReader, Reader>();

        serviceCollection.AddSingleton<IEnergyRepository, EnergyRepository>();

        serviceCollection.AddSingleton<IHarvesterController, HarvesterController>();
        serviceCollection.AddSingleton<IProviderController, ProviderController>();

        serviceCollection.AddSingleton<ICommandInterpreter, CommandInterpreter>();

        return serviceCollection.BuildServiceProvider();
    }
}