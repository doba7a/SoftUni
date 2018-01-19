namespace ClosestTwoPoints
{
    using System;

    public class ClosestTwoPoints
    {
        public static void Main()
        {
            int numberOfPoints = int.Parse(Console.ReadLine());

            Point[] arrayOfPoints = new Point[numberOfPoints];

            for (int i = 0; i < numberOfPoints; i++)
            {
                Point currentPoint = Point.ReadPoint(Console.ReadLine());

                arrayOfPoints[i] = currentPoint;
            }

            string minDistanceWithPointData = Point.FindClosestTwoPoints(arrayOfPoints);

            Console.WriteLine(minDistanceWithPointData);
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

        public static string FindClosestTwoPoints(Point[] arrayOfPoints)
        {
            double minDistance = long.MaxValue;
            Point firstPoint = new Point();
            Point secondPoint = new Point();

            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                for (int j = i + 1; j < arrayOfPoints.Length; j++)
                {
                    double currentDistance = Point.CalculateDistance(arrayOfPoints[i], arrayOfPoints[j]);

                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        firstPoint = arrayOfPoints[i];
                        secondPoint = arrayOfPoints[j];
                    }
                }
            }

            string minDistanceWithPointData = 
                $"{minDistance:F3}{Environment.NewLine}({firstPoint.X}, {firstPoint.Y}){Environment.NewLine}({secondPoint.X}, {secondPoint.Y})";

            return minDistanceWithPointData;
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