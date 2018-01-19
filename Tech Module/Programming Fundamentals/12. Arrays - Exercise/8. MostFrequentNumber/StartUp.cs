namespace MostFrequentNumber
{
    using System;
    using System.Linq;

    public class MostFrequentNumber
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int result = arrayOfIntegers.GroupBy(value => value).OrderByDescending(group => group.Count()).First().First();

            Console.WriteLine(result);
        }
    }
}