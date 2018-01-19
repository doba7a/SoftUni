namespace SortNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SortNumbers
    {
        public static void Main()
        {
            List<double> listOfDoubles = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            listOfDoubles.Sort();

            Console.WriteLine(string.Join(" <= ", listOfDoubles));
        }
    }
}