namespace CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int[], List<int>> reverseExclude = (collectionOfNumbers) =>
            {
                List<int> result = new List<int>();
                List<int> odds = new List<int>();

                for (int index = 0; index < collectionOfNumbers.Length; index++)
                {
                    if (collectionOfNumbers[index] % 2 == 0)
                    {
                        result.Add(collectionOfNumbers[index]);
                    }
                }

                result.Sort();

                for (int index = 0; index < collectionOfNumbers.Length; index++)
                {
                    if (collectionOfNumbers[index] % 2 != 0)
                    {
                        odds.Add(collectionOfNumbers[index]);
                    }
                }

                odds.Sort();
                result.AddRange(odds);

                return result;
            };

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            print(reverseExclude(input));
        }
    }
}
