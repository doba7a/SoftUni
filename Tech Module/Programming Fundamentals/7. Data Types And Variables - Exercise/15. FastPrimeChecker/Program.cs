namespace FastPrimeChecker
{
    using System;

    public class FastPrimeChecker
    {
        public static void Main()
        {
            int maxNumber = int.Parse(Console.ReadLine());

            for (int number = 2; number <= maxNumber; number++)
            {
                bool primeOrNot = true;
                for (int divider = 2; divider <= Math.Sqrt(number); divider++)
                {
                    if (number % divider == 0)
                    {
                        primeOrNot = false;
                        break;
                    }
                }
                Console.WriteLine($"{number} -> {primeOrNot}");
            }
        }
    }
}
