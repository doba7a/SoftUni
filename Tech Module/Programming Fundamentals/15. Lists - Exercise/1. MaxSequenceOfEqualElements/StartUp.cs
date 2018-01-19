namespace MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class MaxSequenceOfEqualElements
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int resultNumber = listOfIntegers.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

            listOfIntegers.RemoveAll(x => x != resultNumber);

            Console.WriteLine(string.Join(" ", listOfIntegers));
        }
    }
}