namespace DistanceBetweenPoints
{
    using System;

    public class DistanceBetweenPoints
    {
        public static void Main()
        {
            Point firstPoint = Point.ReadPoint(Console.ReadLine());

            Point secondPoint = Point.ReadPoint(Console.ReadLine());

            double distance = Point.CalculateDistance(firstPoint, secondPoint);

            Console.WriteLine($"{distance:F3}");
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            int sideA = Math.Abs(firstPoint.X - secondPoint.X);
            int sideB = Math.Abs(firstPoint.Y - secondPoint.Y);

            double distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;
        }

        public static Point ReadPoint(string pointData)
        {
            string[] givenPointData = pointData.Split(' ');

            int givenPointX = int.Parse(givenPointData[0]);
            int givenPointY = int.Parse(givenPointData[1]);

            Point givenPoint = new Point
            {
                X = givenPointX,
                Y = givenPointY
            };

            return givenPoint;
        }
    }
}