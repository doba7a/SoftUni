namespace TemperatureConversion
{
    using System;

    public class TemperatureConversion
    {
        public static void Main()
        {
            double fahrenheit = double.Parse(Console.ReadLine());

            double celsius = ConvertFarenheitToCelsius(fahrenheit);

            Console.WriteLine($"{celsius:F2}");
        }

        public static double ConvertFarenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }
    }
}