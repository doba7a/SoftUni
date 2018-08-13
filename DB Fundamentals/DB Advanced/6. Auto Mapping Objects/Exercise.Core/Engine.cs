namespace Exercise.Core
{
    using Microsoft.Extensions.DependencyInjection;

    using Exercise.Core.Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using Exercise.Services;

    public class Engine
    {
        private readonly IServiceProvider sp;

        public Engine(IServiceProvider sp)
        {
            this.sp = sp;
        }

        public void Run()
        {

            IWriter writer = this.sp.GetService<IWriter>();
            IReader reader = this.sp.GetService<IReader>();

            writer.WriteLine("Initializing database. Please wait.");
            IDatabaseInitializerService databaseInitializerService = this.sp.GetService<IDatabaseInitializerService>();
            databaseInitializerService.InitializeDatabase();

            writer.WriteLine("Database initialized.");
            writer.WriteLine("Type \"Help\" for list with available commands.");

            while (true)
            {
                writer.Write("Enter command: ");
                string input = reader.ReadLine();

                try
                {
                    string result = this.ProcessCommand(input);
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine("ERROR: " + ex.Message);
                }
            }
        }

        private string ProcessCommand(string input)
        {
            string[] inputData = input.Split(' ');
            string commandName = inputData[0];
            string[] commandArgs = inputData.Skip(1).ToArray();

            Type[] commandTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                .Contains(typeof(ICommand)))
                .ToArray();

            Type commandType = commandTypes
                .SingleOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            ConstructorInfo constructor = commandType.GetConstructors().First();

            Type[] constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            object[] services = constructorParameters
                .Select(this.sp.GetService)
                .ToArray();

            ICommand command = (ICommand)constructor.Invoke(services);

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
