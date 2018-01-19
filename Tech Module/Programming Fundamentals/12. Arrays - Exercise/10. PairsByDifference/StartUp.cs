namespace PairsByDifference
{
    using System;
    using System.Linq;

    public class PairsByDifference
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < arrayOfIntegers.Length; i++)
            {
                for (int j = i + 1; j < arrayOfIntegers.Length; j++)
                {
                    if (Math.Abs(arrayOfIntegers[i] - arrayOfIntegers[j]) == difference)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}