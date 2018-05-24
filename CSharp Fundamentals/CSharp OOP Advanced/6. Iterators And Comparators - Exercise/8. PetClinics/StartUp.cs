using System;

public class StartUp
{
    public static void Main()
    {
        Engine engine = new Engine();

        string programResult = engine.Run();

        Console.WriteLine(programResult);
    }
}

