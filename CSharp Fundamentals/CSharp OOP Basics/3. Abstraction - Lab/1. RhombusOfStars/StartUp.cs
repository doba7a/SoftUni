using System;

public class StartUp
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        for (int row = 1; row <= rows; row++)
        {
            PrintRow(rows, row);
        }
        for (int row = rows - 1; row > 0; row--)
        {
            PrintRow(rows, row);
        }
    }

    public static void PrintRow(int size, int rowSize)
    {
        for (int counter = 0; counter < size - rowSize; counter++)
        {
            Console.Write(" ");
        }

        for (int counter = 0; counter < rowSize; counter++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}
