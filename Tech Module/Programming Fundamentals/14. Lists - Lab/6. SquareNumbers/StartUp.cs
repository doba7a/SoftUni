namespace SquareNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SquareNumbers
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => Math.Sqrt(x) == (int)Math.Sqrt(x))
                .ToList();

            Console.WriteLine(string.Join(" ", listOfIntegers.OrderByDescending(x => x)));
        }
    }
}