namespace ReverseNumbersWithAStack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            long[] arrayOfNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            Stack<long> stackOfNumbers = new Stack<long>(arrayOfNumbers);

            Console.WriteLine(string.Join(" ", stackOfNumbers));
        }
    }
}
