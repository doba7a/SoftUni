namespace MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class MaxSequenceOfEqualElements
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int start = 0;
            int length = 1;

            int bestStart = 0;
            int bestLength = 0;

            for (int i = 1; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] == arrayOfIntegers[i - 1])
                {
                    length++;
                }
                else
                {
                    start = i;
                    length = 1;
                }

                if (length > bestLength)
                {
                    bestStart = start;
                    bestLength = length;
                }
            }

            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(arrayOfIntegers[bestStart + i] + " ");
            }

            Console.WriteLine();
        }
    }
}