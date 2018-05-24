using System;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        string name = $"{input[0]} {input[1]}";
        string address = input[2];
        string town = input[3];
        Console.WriteLine(new Threeuple<string, string, string>(name, address, town));

        input = Console.ReadLine().Split();
        name = input[0];
        int litersOfBeer = int.Parse(input[1]);
        bool drunk = input[2] == "drunk" ? true : false;
        Console.WriteLine(new Threeuple<string, int, bool>(name, litersOfBeer, drunk));

        input = Console.ReadLine().Split();
        name = input[0];
        double balance = double.Parse(input[1]);
        string bankName = input[2];
        Console.WriteLine(new Threeuple<string, double, string>(name, balance, bankName));
    }
}

