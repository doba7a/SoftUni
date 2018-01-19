namespace FibonacciNumbers
{
    using System;

    public class FibonacciNumbers
    {
        public static void Main()
        {
            int nthFibonacciNumberNeeded = int.Parse(Console.ReadLine());

            int nthFibonacciNumber = FindNthFibonacciNumber(nthFibonacciNumberNeeded);

            Console.WriteLine(nthFibonacciNumber);
        }

        public static int FindNthFibonacciNumber(int nthFibonacciNumberNeeded)
        {
            if (nthFibonacciNumberNeeded == 0 || nthFibonacciNumberNeeded == 1)
            {
                return 1;
            }

            int count = 2;
            int firstDigit = 1;
            int secondDigit = 1;
            int nthFibonacciNumber = 0;

            while (count <= nthFibonacciNumberNeeded)
            {
                nthFibonacciNumber = firstDigit + secondDigit;
                firstDigit = secondDigit;
                secondDigit = nthFibonacciNumber;
                count++;
            }

            return nthFibonacciNumber;
        }
    }
}