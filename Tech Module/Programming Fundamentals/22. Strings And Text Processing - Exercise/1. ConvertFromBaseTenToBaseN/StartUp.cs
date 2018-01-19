namespace ConvertFromBaseTenToBaseN
{
    using System;
    using System.Text;
    using System.Numerics;

    public class ConvertFromBaseTenToBaseN
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ');

            byte baseToConvertTo = byte.Parse(inputData[0]);
            BigInteger numberToConvert = BigInteger.Parse(inputData[1]);

            StringBuilder resultNumber = new StringBuilder();

            while (numberToConvert > 0)
            {
                byte digitToAddToResultNumber = (byte)(numberToConvert % baseToConvertTo);

                resultNumber.Insert(0, digitToAddToResultNumber);

                numberToConvert /= baseToConvertTo;
            }

            Console.WriteLine(resultNumber);
        }
    }
}