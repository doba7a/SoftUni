public class StartUp
{
    public static void Main()
    {
        CustomList<string> customList = new CustomList<string>();

        CommandInterpreter commandInterpreter = new CommandInterpreter(customList);

        commandInterpreter.ReadCommands();
    }
}

