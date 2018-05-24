using System;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        string name = $"{input[0]} {input[1]}";
        string address = input[2];
        Console.WriteLine(new Tuple<string, string>(name, address));

        input = Console.ReadLine().Split();
        name = input[0];
        int litersOfBeer = int.Parse(input[1]);
        Console.WriteLine(new Tuple<string, int>(name, litersOfBeer));

        input = Console.ReadLine().Split();
        int integer = int.Parse(input[0]);
        double doubleValue = double.Parse(input[1]);
        Console.WriteLine(new Tuple<int, double>(integer, doubleValue));
    }
}

