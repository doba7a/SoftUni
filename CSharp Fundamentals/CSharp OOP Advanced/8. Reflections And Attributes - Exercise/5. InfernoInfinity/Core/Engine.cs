using System;
using System.Linq;
using System.Reflection;

public class Engine
{
    private CommandInterpreter commandInterpreter;

    public Engine(CommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] inputData = input.Split(';');

            string[] args = inputData.Skip(1).ToArray();
            string commandName = inputData[0];
            ICommand command = this.commandInterpreter.InterpretCommand(args, commandName);

            MethodInfo method = typeof(ICommand).GetMethods().First(); 

            try
            {
                method.Invoke(command, null);
            }
            catch (Exception)
            {
            }

            input = Console.ReadLine();
        }
    }
}

