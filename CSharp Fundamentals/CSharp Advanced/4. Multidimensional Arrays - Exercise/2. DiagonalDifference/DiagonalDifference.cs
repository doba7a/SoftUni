namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int matrixLength = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixLength, matrixLength];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRowData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRowData[j];
                }
            }

            int firstDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstDiagonalSum += matrix[i, i];
            }

            int secondDiagonalSum = 0;
            int rowCounter = 0;

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                secondDiagonalSum += matrix[i, rowCounter++];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
