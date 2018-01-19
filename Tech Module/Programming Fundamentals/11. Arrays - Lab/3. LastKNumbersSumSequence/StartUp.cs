namespace LastKNumbersSumSequence
{
    using System;

    public class LastKNumbersSumSequence
    {
        public static void Main()
        {
            long arrayLength = long.Parse(Console.ReadLine());

            long[] sequenceArray = new long[arrayLength];

            sequenceArray[0] = 1;

            long numberOfElementsToSum = long.Parse(Console.ReadLine());

            for (long i = 1; i < sequenceArray.Length; i++)
            {
                for (long j = i - numberOfElementsToSum; j < i; j++)
                {
                    if (j >= 0)
                    {
                        sequenceArray[i] += sequenceArray[j];
                    }
                }
            }

            Console.WriteLine(string.Join(" ", sequenceArray));
        }
    }
}