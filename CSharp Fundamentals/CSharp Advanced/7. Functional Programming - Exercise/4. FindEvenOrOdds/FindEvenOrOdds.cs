namespace FindEvenOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvenOrOdds
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int startNumber = input[0];
            int endNumber = input[1];

            bool lookingForEven = Console.ReadLine() == "even";

            Func<int, bool> even = n => (n % 2 == 0) == lookingForEven;

            IEnumerable<int> numCollection = Enumerable.Range(startNumber, endNumber - startNumber + 1).Where(even);

            Action<IEnumerable<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            print(numCollection);
        }
    }
}
