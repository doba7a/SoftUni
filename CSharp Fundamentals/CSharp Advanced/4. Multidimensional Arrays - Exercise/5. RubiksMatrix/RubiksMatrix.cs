namespace RubiksMatrix
{
    using System;
    using System.Linq;

    public class RubiksMatrix
    {
        public static void Main()
        {
            int[,] matrix = ReadTheMatrix();

            RotateTheMatrix(matrix);

            RearrangeTheMatrixAndPrintOutput(matrix);
        }

        public static int[,] ReadTheMatrix()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            int[,] matrix = new int[rows, columns];
            int counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = counter++;
                }
            }

            return matrix;
        }

        public static void RotateTheMatrix(int[,] matrix)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] currentCommandData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int index = int.Parse(currentCommandData[0]);
                string direction = currentCommandData[1];
                int rotations = int.Parse(currentCommandData[2]);

                switch (direction)
                {
                    case "left":
                    case "right":
                        RotateRow(index, direction, rotations, matrix);
                        break;
                    case "up":
                    case "down":
                        RotateColumn(index, direction, rotations, matrix);
                        break;
                }
            }
        }

        public static void RotateRow(int rowIndex, string direction, int rotations, int[,] matrix)
        {
            int[] rowValues = new int[matrix.GetLength(1)];

            for (int i = 0; i < rowValues.Length; i++)
            {
                rowValues[i] = matrix[rowIndex, i];
            }

            switch (direction)
            {
                case "left":
                    RotateArrayToLeft(rotations, rowValues);
                    break;
                case "right":
                    RotateArrayToRight(rotations, rowValues);
                    break;
            }

            for (int i = 0; i < rowValues.Length; i++)
            {
                matrix[rowIndex, i] = rowValues[i];
            }
        }

        public static void RotateColumn(int columnIndex, string direction, int rotations, int[,] matrix)
        {
            int[] columnValues = new int[matrix.GetLength(0)];

            for (int i = 0; i < columnValues.Length; i++)
            {
                columnValues[i] = matrix[i, columnIndex];
            }

            switch (direction)
            {
                case "up":
                    RotateArrayToLeft(rotations, columnValues);
                    break;
                case "down":
                    RotateArrayToRight(rotations, columnValues);
                    break;
            }

            for (int i = 0; i < columnValues.Length; i++)
            {
                matrix[i, columnIndex] = columnValues[i];
            }
        }

        public static void RotateArrayToLeft(int rotations, int[] columnValues)
        {
            int actualRotations = rotations % columnValues.Length;

            for (int i = 0; i < actualRotations; i++)
            {
                int tempValue = columnValues[0];
                Array.Copy(columnValues, 1, columnValues, 0, columnValues.Length - 1);
                columnValues[columnValues.Length - 1] = tempValue;
            }
        }

        public static void RotateArrayToRight(int rotations, int[] columnValues)
        {
            int actualRotations = rotations % columnValues.Length;

            for (int i = 0; i < actualRotations; i++)
            {
                int tempValue = columnValues[columnValues.Length - 1];
                Array.Copy(columnValues, 0, columnValues, 1, columnValues.Length - 1);
                columnValues[0] = tempValue;
            }
        }

        public static void RearrangeTheMatrixAndPrintOutput(int[,] matrix)
        {
            int counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int currentElement = matrix[row, column];

                    if (currentElement == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        int[] coordinates = GetCoordinates(matrix, counter);

                        int rowToSwapWith = coordinates[0];
                        int columnToSwapWith = coordinates[1];

                        matrix[row, column] = counter;
                        matrix[rowToSwapWith, columnToSwapWith] = currentElement;
                        counter++;

                        Console.WriteLine($"Swap ({row}, {column}) with ({rowToSwapWith}, {columnToSwapWith})");
                    }
                }
            }
        }

        public static int[] GetCoordinates(int[,] matrix, int value)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int currentElement = matrix[row, column];

                    if (currentElement == value)
                    {
                        coordinates[0] = row;
                        coordinates[1] = column;

                        return coordinates;
                    }
                }
            }

            return coordinates;
        }
    }
}
