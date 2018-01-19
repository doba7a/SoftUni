namespace WeatherForecast
{
    using System;

    public class WeatherForecast
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            sbyte sbyteNumber = 0;
            int intNumber = 0;
            long longNumber = 0;

            if (sbyte.TryParse(input, out sbyteNumber))
            {
                Console.WriteLine("Sunny");
            }
            else if (int.TryParse(input, out intNumber))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(input, out longNumber))
            {
                Console.WriteLine("Windy");
            }
            else
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}