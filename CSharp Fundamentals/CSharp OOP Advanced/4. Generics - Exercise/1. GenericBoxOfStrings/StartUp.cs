using System;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string input = Console.ReadLine();

            Box<string> stringBox = new Box<string>(input);

            Console.WriteLine(stringBox.ToString());
        }
    }
}

