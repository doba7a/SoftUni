using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] rectangleData = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Point bottomLeft = new Point(rectangleData[0], rectangleData[1]);
        Point topRight = new Point(rectangleData[2], rectangleData[3]);
        Rectangle rectangle = new Rectangle(bottomLeft, topRight);

        int numberOfPoints = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPoints; i++)
        {
            int[] currentPointData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Point currentPoint = new Point(currentPointData[0], currentPointData[1]);

            Console.WriteLine(rectangle.ContainsPoint(currentPoint) ? "True" : "False");
        }
    }
}
