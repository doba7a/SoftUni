using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[,] matrix = ReadMatrix();

        string command = Console.ReadLine();

        long sum = 0;

        while (command != "Let the Force be with you")
        {
            int[] ivoCoordinates = command
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] evilPowerCoordinates = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            DestroyStars(matrix, evilPowerCoordinates);

            CollectStars(matrix, ivoCoordinates, ref sum);

            command = Console.ReadLine();
        }

        Console.WriteLine(sum);

    }

    public static int[,] ReadMatrix()
    {
        int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int x = dimensions[0];
        int y = dimensions[1];

        int[,] matrix = new int[x, y];

        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = value++;
            }
        }

        return matrix;
    }

    public static void DestroyStars(int[,] matrix, int[] evilPowerCoordinates)
    {
        int evilPowerX = evilPowerCoordinates[0];
        int evilPowerY = evilPowerCoordinates[1];

        while (evilPowerX >= 0 && evilPowerY >= 0)
        {
            if (evilPowerX >= 0 && evilPowerX < matrix.GetLength(0) && evilPowerY >= 0 && evilPowerY < matrix.GetLength(1))
            {
                matrix[evilPowerX, evilPowerY] = 0;
            }
            evilPowerX--;
            evilPowerY--;
        }
    }

    public static void CollectStars(int[,] matrix, int[] ivoCoordinates, ref long sum)
    {
        int ivoX = ivoCoordinates[0];
        int ivoY = ivoCoordinates[1];

        while (ivoX >= 0 && ivoY < matrix.GetLength(1))
        {
            if (ivoX >= 0 && ivoX < matrix.GetLength(0) && ivoY >= 0 && ivoY < matrix.GetLength(1))
            {
                sum += matrix[ivoX, ivoY];
            }

            ivoY++;
            ivoX--;
        }
    }
}

