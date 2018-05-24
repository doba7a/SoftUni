using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

        if (commandType == null || !typeof(ICommand).IsAssignableFrom(commandType))
        {
            return null;
        }

        FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

        object[] constrArgs = new object[] { data }.Concat(injectArgs).ToArray();

        ICommand instance = (ICommand)Activator.CreateInstance(commandType, constrArgs);

        return instance;
    }


}

