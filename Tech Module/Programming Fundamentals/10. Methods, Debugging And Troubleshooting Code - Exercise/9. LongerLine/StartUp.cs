namespace LongerLine
{
    using System;

    public class LongerLine
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLineLength = LineLength(x1, y1, x2, y2);
            double secondLineLength = LineLength(x3, y3, x4, y4);

            if (firstLineLength >= secondLineLength)
            {
                string result = CloserToCenter(x1, y1, x2, y2);
                Console.WriteLine(result);
            }

            else
            {
                string result = CloserToCenter(x3, y3, x4, y4);
                Console.WriteLine(result);
            }
        }

        public static double LineLength(double x1, double y1, double x2, double y2)
        {
            var xDifference = Math.Abs(x1 - x2);
            var yDiffrence = Math.Abs(y1 - y2);

            var lineLength = Math.Sqrt(xDifference * xDifference + yDiffrence * yDiffrence);

            return lineLength;
        }

        public static string CloserToCenter(double x1, double y1, double x2, double y2)
        {
            string result = string.Empty;

            if (x1 * x1 + y1 * y1 <= x2 * x2 + y2 * y2)
            {
                result = $"({x1}, {y1})({x2}, {y2})";
            }
            else
            {
                result = $"({x2}, {y2})({x1}, {y1})";
            }

            return result;
        }
    }
}