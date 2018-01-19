namespace CirclesIntersection
{
    using System;
    using System.Linq;

    public class CirclesIntersection
    {
        public static void Main()
        {
            Circle firstCircle = Circle.ReadCircle(Console.ReadLine());
            Circle secondCircle = Circle.ReadCircle(Console.ReadLine());

            string result = Circle.Intersect(firstCircle, secondCircle);

            Console.WriteLine(result);
        }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public static string Intersect(Circle firstCircle, Circle secondCircle)
        {
            double distanceBetweenCenters = Point.CalculateDistance(firstCircle.Center, secondCircle.Center);
            double sumOfRadiuses = firstCircle.Radius + secondCircle.Radius;

            if (distanceBetweenCenters <= sumOfRadiuses)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public static Circle ReadCircle(string circleData)
        {
            int[] currentCircleData = circleData.Split(' ').Select(int.Parse).ToArray();

            int currentCircleCenterPointX = currentCircleData[0];
            int currentCircleCenterPointY = currentCircleData[1];
            Point currentCircleCenterPoint = new Point
            {
                X = currentCircleCenterPointX,
                Y = currentCircleCenterPointY
            };

            int currentCircleRadius = currentCircleData[2];

            Circle currentCircle = new Circle
            {
                Center = currentCircleCenterPoint,
                Radius = currentCircleRadius
            };

            return currentCircle;
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
    }
}