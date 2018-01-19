namespace SumReversedNumbers
{
    using System;
    using System.Linq;

    public class SumReversedNumbers
    {
        public static void Main()
        {
            int sumOfReversedIntegers = Console.ReadLine()
                .Split(' ')
                .Select(x => new String(x.Reverse().ToArray()))
                .Sum(x => int.Parse(x));

            Console.WriteLine(sumOfReversedIntegers);
        }
    }
}