namespace MilesToKilometers
{
    using System;

    public class MilesToKilometers
    {
        public static void Main()
        {
            var miles = double.Parse(Console.ReadLine());

            var kilometers = miles * 1.60934;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}