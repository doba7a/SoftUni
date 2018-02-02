namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            Queue<string> players = new Queue<string>(input);

            int n = int.Parse(Console.ReadLine());
            int currentCounter = 1;

            while (players.Count > 1)
            {
                if (currentCounter == n)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    currentCounter = 1;
                    continue;
                }

                players.Enqueue(players.Dequeue());
                currentCounter++;
            }

            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
