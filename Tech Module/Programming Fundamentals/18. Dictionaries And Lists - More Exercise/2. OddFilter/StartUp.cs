namespace OddFilter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class OddFilter
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x % 2 == 0).ToArray();

            double averageValue = arrayOfIntegers.Average();

            for (int i = 0; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] > averageValue)
                {
                    arrayOfIntegers[i]++;
                }
                else if (arrayOfIntegers[i] <= averageValue)
                {
                    arrayOfIntegers[i]--;
                }
            }

            Console.WriteLine(string.Join(" ", arrayOfIntegers));
        }
    }
}