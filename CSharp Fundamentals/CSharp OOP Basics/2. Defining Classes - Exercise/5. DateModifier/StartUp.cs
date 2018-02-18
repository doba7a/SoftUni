using System;

public class StartUp
{
    static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        int days = DateModifier.DateDifference(firstDate, secondDate);

        Console.WriteLine(days);
    }
}

