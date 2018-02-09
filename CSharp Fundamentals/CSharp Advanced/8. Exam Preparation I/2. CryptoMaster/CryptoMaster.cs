namespace CryptoMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main()
        {
            int[] inputSequence = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestCount = int.MinValue;
            int currentCount = 1;

            for (int startingIndex = 0; startingIndex < inputSequence.Length; startingIndex++)
            {
                int tempValue = inputSequence[startingIndex];
                int tempIndex = startingIndex;
                int stepSize = 1;

                while (stepSize <= inputSequence.Length)
                {
                    int nextIndex = (tempIndex + stepSize) % inputSequence.Length;

                    if (inputSequence[nextIndex] > tempValue)
                    {
                        tempValue = inputSequence[nextIndex];
                        tempIndex = nextIndex;
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount > longestCount)
                        {
                            longestCount = currentCount;
                        }
                        tempValue = inputSequence[startingIndex];
                        tempIndex = startingIndex;
                        currentCount = 1;
                        stepSize++;
                    }
                }
            }

            Console.WriteLine(longestCount);
        }
    }
}
