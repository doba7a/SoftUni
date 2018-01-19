namespace RemoveNegativesAndReverse
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RemoveNegativesAndReverse
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x >= 0)
                .Reverse()
                .ToList();

            if (listOfIntegers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", listOfIntegers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}