namespace CenterPoint
{
    using System;

    public class CenterPoint
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            if (CalculatePointDistanceFromCenter(x1, y1) <= CalculatePointDistanceFromCenter(x2, y2))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        private static double CalculatePointDistanceFromCenter(double x2, double y2)
        {
            double givenPointDistanceFromCenter = (x2 - 0) * (x2 - 0) + (y2 - 0) * (y2 - 0);
            return givenPointDistanceFromCenter;
        }
    }
}