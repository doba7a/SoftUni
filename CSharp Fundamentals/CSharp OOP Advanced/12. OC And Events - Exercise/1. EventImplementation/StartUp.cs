using System;

public class StartUp
{
    public static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler(new ConsoleWriter());

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string dispatcherName = Console.ReadLine();

        while (dispatcherName != "End")
        {
            dispatcher.Name = dispatcherName;
            dispatcherName = Console.ReadLine();
        }
    }
}

