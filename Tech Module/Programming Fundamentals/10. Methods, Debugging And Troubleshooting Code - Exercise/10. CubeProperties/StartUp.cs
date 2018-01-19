namespace CubeProperties
{
    using System;

    public class CubeProperties
    {
        public static void Main()
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string propertyToCalculate = Console.ReadLine();

            CalculateGivenProperty(cubeSide, propertyToCalculate);
        }

        public static void CalculateGivenProperty(double cubeSide, string propertyToCalculate)
        {
            switch (propertyToCalculate)
            {
                case "face":
                    double face = Math.Sqrt(2 * cubeSide * cubeSide);
                    Console.WriteLine($"{face:F2}");
                    break;
                case "space":
                    double space = Math.Sqrt(3 * cubeSide * cubeSide);
                    Console.WriteLine($"{space:F2}");
                    break;
                case "volume":
                    double volume = cubeSide * cubeSide * cubeSide;
                    Console.WriteLine($"{volume:F2}");
                    break;
                case "area":
                    double area = 6 * cubeSide * cubeSide;
                    Console.WriteLine($"{area:F2}");
                    break;
            }
        }
    }
}