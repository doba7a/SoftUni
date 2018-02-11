namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            List<int> bullets = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> locks = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int bulletCounter = bullets.Count - 1;
            int totalBullets = 0;
            int bulletsShotWithThisBarrel = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int currentBullet = bullets[bulletCounter];
                int currentLock = locks[0];

                if (currentBullet <= currentLock)
                {
                    bullets.RemoveAt(bulletCounter);
                    locks.RemoveAt(0);

                    totalBullets++;
                    bulletsShotWithThisBarrel++;
                    bulletCounter--;

                    Console.WriteLine("Bang!");
                }
                else
                {
                    bullets.RemoveAt(bulletCounter);

                    totalBullets++;
                    bulletsShotWithThisBarrel++;
                    bulletCounter--;

                    Console.WriteLine("Ping!");
                }

                if (bulletsShotWithThisBarrel == sizeOfGunBarrel && bullets.Count > 0)
                {
                    bulletsShotWithThisBarrel = 0;

                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                int moneyEarned = valueOfIntelligence - (totalBullets * pricePerBullet);

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
