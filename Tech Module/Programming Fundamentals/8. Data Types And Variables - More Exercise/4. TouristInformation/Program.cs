namespace TouristInformation
{
    using System;

    public class TouristInformation
    {
        public static void Main()
        {
            string initialUnit = Console.ReadLine();
            double initialUnitValue = double.Parse(Console.ReadLine());

            switch (initialUnit)
            {
                case "miles":
                    double kilometersValue = initialUnitValue * 1.6;
                    Console.WriteLine($"{initialUnitValue} {initialUnit} = {kilometersValue:F2} kilometers");
                    break;
                case "inches":
                    double centimetersFromInchValue = initialUnitValue * 2.54;
                    Console.WriteLine($"{initialUnitValue} {initialUnit} = {centimetersFromInchValue:F2} centimeters");
                    break;
                case "feet":
                    double centimetersFromFeetValue = initialUnitValue * 30.0;
                    Console.WriteLine($"{initialUnitValue} {initialUnit} = {centimetersFromFeetValue:F2} centimeters");
                    break;
                case "yards":
                    double metersValue = initialUnitValue * 0.91;
                    Console.WriteLine($"{initialUnitValue} {initialUnit} = {metersValue:F2} meters");
                    break;
                case "gallons":
                    double litersValue = initialUnitValue * 3.8;
                    Console.WriteLine($"{initialUnitValue} {initialUnit} = {litersValue:F2} liters");
                    break;
            }
        }
    }
}