namespace Crossfire
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            int[][] jagged = CreateTheJaggedArray();

            string input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                int[] destructionData = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Destruction(destructionData, ref jagged);

                input = Console.ReadLine();
            }

            PrintResultJagged(jagged);
        }

        public static int[][] CreateTheJaggedArray()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            int[][] jagged = new int[rows][];
            int counter = 1;

            for (int row = 0; row < rows; row++)
            {
                jagged[row] = new int[columns];
                for (int column = 0; column < columns; column++)
                {
                    jagged[row][column] = counter++;
                }
            }

            return jagged;
        }

        public static void Destruction(int[] destructionData, ref int[][] jagged)
        {
            int destructionRow = destructionData[0];
            int destructionColumn = destructionData[1];
            int destructionRange = destructionData[2];

            int startingRow = destructionRow - destructionRange;
            int endingRow = destructionRow + destructionRange;

            for (int row = startingRow; row <= endingRow; row++)
            {
                if (ValidCoordinates(row, destructionColumn, jagged))
                {
                    jagged[row][destructionColumn] = -1;
                }
            }

            int startingColumn = destructionColumn - destructionRange;
            int endingColumn = destructionColumn + destructionRange;

            for (int column = startingColumn; column <= endingColumn; column++)
            {
                if (ValidCoordinates(destructionRow, column, jagged))
                {
                    jagged[destructionRow][column] = -1;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                if (jagged[row].Any(x => x == -1))
                {
                    jagged[row] = jagged[row].Where(x => x != -1).ToArray();
                }

                if (jagged[row].Length == 0)
                {
                    jagged = jagged.Take(row).Concat(jagged.Skip(row + 1)).ToArray();
                    row--;
                }
            }
        }

        public static bool ValidCoordinates(int row, int column, int[][] jagged)
        {
            if (row >= 0 && row < jagged.Length && column >= 0 && column < jagged[row].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PrintResultJagged(int[][] jagged)
        {
            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row.Where(n => n > 0)));
            }
        }
    }
}
