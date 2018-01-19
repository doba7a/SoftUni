namespace Heists
{
    using System;
    using System.Linq;

    public class Heists
    {
        public static void Main()
        {
            int[] lootPrice = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string currentLootData = Console.ReadLine();

            int jewelPrice = lootPrice[0];
            int goldPrice = lootPrice[1];
            long totalLootValue = 0;
            long totalExpenses = 0;

            while (currentLootData != "Jail Time")
            {
                string currentLoot = currentLootData.Split(' ')[0];
                int currentLootExpenses = int.Parse(currentLootData.Split(' ')[1]);

                int jewelsFound = currentLootData.Where(x => x == '%').ToArray().Length;
                int goldFound = currentLootData.Where(x => x == '$').ToArray().Length;

                totalLootValue += jewelsFound * jewelPrice + goldFound * goldPrice;
                totalExpenses += currentLootExpenses;

                currentLootData = Console.ReadLine();
            }

            if (totalLootValue >= totalExpenses)
            {
                long profit = totalLootValue - totalExpenses;
                Console.WriteLine($"Heists will continue. Total earnings: {profit}.");
            }
            else
            {
                long moneyLost = totalExpenses - totalLootValue;
                Console.WriteLine($"Have to find another job. Lost: {moneyLost}.");
            }
        }
    }
}