namespace ArrayStatistics
{
    using System;
    using System.Linq;

    public class ArrayStatistics
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int minValue = arrayOfIntegers.Min();
            int maxValue = arrayOfIntegers.Max();
            int sum = arrayOfIntegers.Sum();
            double averageValue = arrayOfIntegers.Average();

            Console.WriteLine($"Min = {minValue}");
            Console.WriteLine($"Max = {maxValue}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {averageValue}");
        }
    }
}