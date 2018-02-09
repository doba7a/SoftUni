namespace PredicateForNames
{
    using System;
    using System.Collections.Generic;

    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string[], int, List<string>> reverseExclude = (collectionOfNumbers, division) =>
            {
                List<string> result = new List<string>();

                for (int index = 0; index < collectionOfNumbers.Length; index++)
                {
                    if (collectionOfNumbers[index].Length <= length)
                    {
                        result.Add(collectionOfNumbers[index]);
                    }
                }

                return result;
            };

            Action<List<string>> print = numbers => Console.WriteLine(String.Join("\n", numbers));

            print(reverseExclude(input, length));
        }
    }
}
