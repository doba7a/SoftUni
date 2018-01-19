namespace largestThreeNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class largestThreeNumbers
    {
        public static void Main()
        {
            List<int> resultList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.Write(String.Join(" ", resultList));
        }
    }
}