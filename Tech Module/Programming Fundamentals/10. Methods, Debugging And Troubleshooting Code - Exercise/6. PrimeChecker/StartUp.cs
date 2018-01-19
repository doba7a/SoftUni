namespace PrimeChecker
{
    using System;

    public class PrimeChecker
    {
        public static void Main()
        {
            long numberToCheck = Math.Abs(long.Parse(Console.ReadLine()));

            Console.WriteLine(IsPrime(numberToCheck));
        }

        public static bool IsPrime(long numberToCheck)
        {
            if (numberToCheck == 0 || numberToCheck == 1)
            {
                return false;
            }

            for (long i = 2; i <= Math.Sqrt(numberToCheck); i++)
            {
                if (numberToCheck % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}