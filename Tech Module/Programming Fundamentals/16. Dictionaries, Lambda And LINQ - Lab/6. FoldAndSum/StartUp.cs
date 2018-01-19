namespace FoldAndSum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FoldAndSum
    {
        public static void Main()
        {
            List<int> initialListOfInts = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int length = initialListOfInts.Count;

            List<int> firstRowFirstPart = initialListOfInts.Take(length / 4).ToList();
            firstRowFirstPart.Reverse();

            List<int> firstRowSecondPart = initialListOfInts.Skip(length / 4 * 3).ToList();
            firstRowSecondPart.Reverse();

            List<int> firstRow = firstRowFirstPart.Concat(firstRowSecondPart).ToList();

            List<int> secondRow = initialListOfInts.Skip(length / 4).Take(length / 2).ToList();

            List<int> resultList = new List<int>();

            for (int i = 0; i < length / 2; i++)
            {
                resultList.Add(firstRow[i] + secondRow[i]);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}