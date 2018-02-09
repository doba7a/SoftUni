namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int divisioner = int.Parse(Console.ReadLine());

            Func<int[], int, List<int>> reverseExclude = (collectionOfNumbers, division) =>
            {
                List<int> numbers = new List<int>();

                for (int index = 0; index < collectionOfNumbers.Length; index++)
                {
                    numbers.Add(collectionOfNumbers[collectionOfNumbers.Length - 1 - index]);
                }

                for (int index = 0; index < collectionOfNumbers.Length; index++)
                {
                    if (collectionOfNumbers[index] % division == 0)
                    {
                        numbers.Remove(collectionOfNumbers[index]);
                    }
                }

                return numbers;
            };

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            print(reverseExclude(input, divisioner));

        }
    }
}
