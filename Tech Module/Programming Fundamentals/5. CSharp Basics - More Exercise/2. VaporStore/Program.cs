namespace VaporStore
{
    using System;
    using System.Collections.Generic;

    public class VaporStore
    {
        public static void Main()
        {
            var balance = double.Parse(Console.ReadLine());
            var totalSpent = 0.0;

            var gamesDictionary = new Dictionary<string, double>()
            {
                { "OutFall 4", 39.99 },
                { "CS: OG", 15.99 },
                { "Zplinter Zell", 19.99 },
                { "Honored 2", 59.99 },
                { "RoverWatch", 29.99 },
                { "RoverWatch Origins Edition", 39.99 }
            };

            var command = Console.ReadLine();

            while (command != "Game Time")
            {
                if (!gamesDictionary.ContainsKey(command))
                {
                    Console.WriteLine("Not Found");
                    command = Console.ReadLine();
                    continue;
                }

                if (gamesDictionary[command] > balance)
                {
                    Console.WriteLine("Too Expensive");
                    command = Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"Bought {command}");
                balance -= gamesDictionary[command];
                totalSpent += gamesDictionary[command];

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    Environment.Exit(1);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
        }
    }
}