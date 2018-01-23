namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = inputData[0];
            int elementsToPop = inputData[1];
            int integerToLookFor = inputData[2];

            int[] arrayOfNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackOfNumbers = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                stackOfNumbers.Push(arrayOfNumbers[i]);
            }

            if (stackOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(1);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                if (stackOfNumbers.Count > 0)
                {
                    stackOfNumbers.Pop();
                }
            }

            if (stackOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(1);
            }

            if (stackOfNumbers.Contains(integerToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackOfNumbers.Min());
            }
        }
    }
}
