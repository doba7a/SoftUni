using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] inputConstrains = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int rectanglesGiven = int.Parse(inputConstrains[0]);
        Rectangle[] rectanglesData = new Rectangle[rectanglesGiven];

        for (int i = 0; i < rectanglesGiven; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Rectangle currentRectangle = CreateRectangle(inputData);

            rectanglesData[i] = currentRectangle;
        }

        int intersectionsCheck = int.Parse(inputConstrains[1]);

        for (int i = 0; i < intersectionsCheck; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string firstRectangleId = inputData[0];
            Rectangle firstRectangle = rectanglesData.FirstOrDefault(r => r.Id == firstRectangleId);

            string secondRectangleId = inputData[1];
            Rectangle secondRectangle = rectanglesData.FirstOrDefault(r => r.Id == secondRectangleId);

            Console.WriteLine(Rectangle.Intersect(firstRectangle, secondRectangle) ? "true" : "false");
        }
    }

    private static Rectangle CreateRectangle(string[] inputData)
    {
        string currentId = inputData[0];

        int currentWidth = int.Parse(inputData[1]);

        int currentHeight = int.Parse(inputData[2]);

        double[] currentTopLeftCoordinates = new double[2];
        currentTopLeftCoordinates[0] = double.Parse(inputData[3]);
        currentTopLeftCoordinates[1] = double.Parse(inputData[4]);

        Rectangle currentRectangle = new Rectangle(currentId, currentWidth, currentHeight, currentTopLeftCoordinates);

        return currentRectangle;
    }
}


