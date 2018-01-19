namespace CountNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CountNumbers
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            SortedDictionary<int, int> resultDictionary = new SortedDictionary<int, int>();

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if (!resultDictionary.ContainsKey(listOfIntegers[i]))
                {
                    resultDictionary[listOfIntegers[i]] = 0;
                }
                resultDictionary[listOfIntegers[i]]++;
            }

            foreach (var number in resultDictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}