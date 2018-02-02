namespace RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        public static long[] FibonacciSequence;

        public static void Main()
        {
            long n = long.Parse(Console.ReadLine());

            FibonacciSequence = new long[n + 1];

            Console.WriteLine(Fibonacci(n));
        }

        public static long Fibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (FibonacciSequence[n] != 0)
            {
                return FibonacciSequence[n];
            }

            FibonacciSequence[n] = Fibonacci(n - 1) + Fibonacci(n - 2);

            return FibonacciSequence[n];
        }
    }
}
