namespace SumOfOddNumbers
{
    using System;

    public class SumOfOddNumbers
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 0; i < 2 * n; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}