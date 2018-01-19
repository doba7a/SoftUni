namespace NeighbourWars
{
    using System;

    public class NeighbourWars
    {
        public static void Main()
        {
            var peshoDamage = int.Parse(Console.ReadLine());
            var goshoDamage = int.Parse(Console.ReadLine());

            var round = 1;
            var peshoHealth = 100;
            var goshoHealth = 100;

            while (true)
            {
                goshoHealth -= peshoDamage;

                if (goshoHealth <= 0)
                {
                    Console.WriteLine($"Pesho won in {round}th round.");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");

                if (round % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }

                round++;

                peshoHealth -= goshoDamage;

                if (peshoHealth <= 0)
                {
                    Console.WriteLine($"Gosho won in {round}th round.");
                    Environment.Exit(1);
                }

                Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");

                if (round % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }

                round++;
            }
        }
    }
}