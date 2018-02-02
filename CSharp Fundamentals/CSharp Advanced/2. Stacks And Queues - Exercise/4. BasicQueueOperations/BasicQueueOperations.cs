namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = inputData[0];
            int elementsToDequeue = inputData[1];
            int integerToLookFor = inputData[2];

            int[] arrayOfNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfNumbers = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queueOfNumbers.Enqueue(arrayOfNumbers[i]);
            }

            if (queueOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(1);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                if (queueOfNumbers.Count > 0)
                {
                    queueOfNumbers.Dequeue();
                }
            }

            if (queueOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(1);
            }

            if (queueOfNumbers.Contains(integerToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queueOfNumbers.Min());
            }
        }
    }
}
