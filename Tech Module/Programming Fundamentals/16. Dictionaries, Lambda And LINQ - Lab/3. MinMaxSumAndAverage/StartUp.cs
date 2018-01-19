namespace MinMaxSumAndAverage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MinMaxSumAndAverage
    {
        public static void Main()
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<int> listOfIntegers = new List<int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                listOfIntegers.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine($"Sum = {listOfIntegers.Sum()}");
            Console.WriteLine($"Min = {listOfIntegers.Min()}");
            Console.WriteLine($"Max = {listOfIntegers.Max()}");
            Console.WriteLine($"Average = {listOfIntegers.Average()}");
        }
    }
}