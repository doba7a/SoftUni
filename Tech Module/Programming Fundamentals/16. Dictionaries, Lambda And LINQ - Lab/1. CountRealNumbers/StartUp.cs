namespace CountRealNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CountRealNumbers
    {
        public static void Main()
        {
            List<double> listOfDoubles = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            SortedDictionary<double, int> resultDictionary = new SortedDictionary<double, int>();

            for (int i = 0; i < listOfDoubles.Count; i++)
            {
                if (!resultDictionary.ContainsKey(listOfDoubles[i]))
                {
                    resultDictionary[listOfDoubles[i]] = 0;
                }
                resultDictionary[listOfDoubles[i]]++;
            }

            foreach (var number in resultDictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}