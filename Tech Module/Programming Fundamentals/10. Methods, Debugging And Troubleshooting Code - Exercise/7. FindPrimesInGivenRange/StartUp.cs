namespace FindPrimesInGivenRange
{
    using System;
    using System.Collections.Generic;

    public class FindPrimesInGivenRange
    {
        public static void Main()
        {
            long startNumber = Math.Abs(long.Parse(Console.ReadLine()));
            long endNumber = Math.Abs(long.Parse(Console.ReadLine()));

            List<long> primesList = GenerateListWithPrimesInGivenRange(startNumber, endNumber);

            if (primesList.Count == 0)
            {
                Console.WriteLine("(empty list)");
            }
            else
            {
                Console.WriteLine(string.Join(", ", primesList));
            }
        }

        public static List<long> GenerateListWithPrimesInGivenRange(long startNumber, long endNumber)
        {
            List<long> primesList = new List<long>();

            if (startNumber < 2)
            {
                startNumber = 2;
            }

            for (long i = startNumber; i <= endNumber; i++)
            {
                bool isPrime = true;

                for (long j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primesList.Add(i);
                }
            }

            return primesList;
        }
    }
}