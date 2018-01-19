namespace mathPower
{
    using System;

    public class mathPower
    {
        public static void Main()
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double powerNumber = double.Parse(Console.ReadLine());

            double result = mathPowerResult(baseNumber, powerNumber);

            Console.WriteLine(result);
        }

        public static double mathPowerResult(double baseNumber, double powerNumber)
        {
            double result = 1d;

            for (int i = 1; i <= powerNumber; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}