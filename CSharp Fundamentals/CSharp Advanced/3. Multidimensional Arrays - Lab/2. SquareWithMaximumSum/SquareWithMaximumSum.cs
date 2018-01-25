namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            int[] currentMatrixData = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = currentMatrixData[0];
            int columns = currentMatrixData[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRowData = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRowData[column];
                }
            }

            int[,] maxSquare = new int[2, 2];
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    int firstElement = matrix[row, column];
                    int secondElement = matrix[row, column + 1];
                    int thirdElement = matrix[row + 1, column];
                    int fourthElement = matrix[row + 1, column + 1];

                    int currentSum = firstElement + secondElement + thirdElement + fourthElement;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSquare = new int[,]
                        {
                            { firstElement, secondElement },
                            { thirdElement, fourthElement }
                        };
                    }
                }
            }

            for (int row = 0; row < maxSquare.GetLength(0); row++)
            {
                for (int column = 0; column < maxSquare.GetLength(1); column++)
                {
                    int currentElement = maxSquare[row, column];

                    Console.Write(currentElement + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
