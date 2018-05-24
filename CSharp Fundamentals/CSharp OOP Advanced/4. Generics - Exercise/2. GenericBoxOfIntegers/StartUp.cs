using System;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> intBox = new Box<int>(input);

            Console.WriteLine(intBox.ToString());
        }
    }
}


