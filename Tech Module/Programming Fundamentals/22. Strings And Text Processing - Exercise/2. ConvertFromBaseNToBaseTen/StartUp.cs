namespace ConvertFromBaseNToBaseTen
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ConvertFromBaseNToBaseTen
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ');

            int baseToConvertFrom = int.Parse(inputData[0]);
            char[] numberToConvert = inputData[1].ToCharArray();

            BigInteger resultNumber = 0;
            int currentPow = 0;

            foreach (char digit in numberToConvert.Reverse())
            {
                int currentDigit = digit - 48;
                resultNumber += (BigInteger)(currentDigit * BigInteger.Pow(baseToConvertFrom, currentPow++));
            }

            Console.WriteLine(resultNumber);
        }
    }
}