namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!"); int endNumber = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int[], List<int>> reverseExclude = (lastNumber, collectionOfNumbers) =>
            {
                List<int> result = new List<int>();

                for (int index = 1; index <= lastNumber; index++)
                {
                    if (IsDivisible(index, collectionOfNumbers))
                    {
                        result.Add(index);
                    }
                }

                return result;
            };

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            print(reverseExclude(endNumber, input));
        }

        public static bool IsDivisible(int number, int[] collectionOfNumbers)
        {
            for (int i = 0; i < collectionOfNumbers.Length; i++)
            {
                if (number % collectionOfNumbers[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
