namespace FactorialTrailingZeroes
{
    using System;
    using System.Numerics;

    public class FactorialTrailingZeroes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CountFactorialTrailingZeroes(n));
        }

        public static int CountFactorialTrailingZeroes(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }

            int lastDigit = (int)(factorial % 10);
            int countOfTrailingZeroes = 0;

            while (lastDigit == 0)
            {
                countOfTrailingZeroes++;
                factorial /= 10;
                lastDigit = (int)(factorial % 10);
            }

            return countOfTrailingZeroes;
        }
    }
}