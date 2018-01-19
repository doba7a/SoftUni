namespace WaterOverflow
{
    using System;

    public class WaterOverflow
    {
        public static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            int totalWaterPouredIntoTank = 0;

            for (int i = 0; i < numberOfInputs; i++)
            {
                int currentWaterQuantity = int.Parse(Console.ReadLine());

                totalWaterPouredIntoTank += currentWaterQuantity;

                if (totalWaterPouredIntoTank > 255)
                {
                    totalWaterPouredIntoTank -= currentWaterQuantity;
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(totalWaterPouredIntoTank);
        }
    }
}