namespace SumAdjacentEqualNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SumAdjacentEqualNumbers
    {
        public static void Main()
        {
            List<double> listOfIntegers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            for (int i = 1; i < listOfIntegers.Count; i++)
            {
                int lastIndex = i - 1;
                int currentIndex = i;

                if (listOfIntegers[lastIndex] == listOfIntegers[currentIndex])
                {
                    listOfIntegers[lastIndex] += listOfIntegers[currentIndex];
                    listOfIntegers.RemoveAt(currentIndex);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}