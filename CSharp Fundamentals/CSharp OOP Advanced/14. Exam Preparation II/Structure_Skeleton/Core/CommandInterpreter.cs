using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController, IServiceProvider serviceProvider)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
        this.serviceProvider = serviceProvider;
    }

    public IHarvesterController HarvesterController { get => harvesterController; private set => harvesterController = value; }

    public IProviderController ProviderController { get => providerController; private set => providerController = value; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        string result = command.Execute();

        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName + "Command");

        if (commandType == null)
        {
            throw new InvalidOperationException(Constants.CommandNotFound);
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.IsNotACommand, commandName));
        }

        ParameterInfo[] contructorParams = commandType.GetConstructors().First().GetParameters();

        object[] paramsToInject = new object[contructorParams.Length];

        for (int i = 0; i < contructorParams.Length; i++)
        {
            Type paramType = contructorParams[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                paramsToInject[i] = args.Skip(1).ToList();
            }
            else
            {
                paramsToInject[i] = this.serviceProvider.GetService(paramType);
            }         
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, paramsToInject);

        return command;
    }
}

