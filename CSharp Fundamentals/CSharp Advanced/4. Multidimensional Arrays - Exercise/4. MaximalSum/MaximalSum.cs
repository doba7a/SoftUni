namespace MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRowData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRowData[column];
                }
            }

            int[,] maxSquare = new int[3, 3];
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 2; column++)
                {
                    int firstElement = matrix[row, column];
                    int secondElement = matrix[row, column + 1];
                    int thirdElement = matrix[row, column + 2];
                    int fourtElement = matrix[row + 1, column];
                    int fifthElement = matrix[row + 1, column + 1];
                    int sixthElement = matrix[row + 1, column + 2];
                    int seventhElement = matrix[row + 2, column];
                    int eighthElement = matrix[row + 2, column + 1];
                    int ninthElement = matrix[row + 2, column + 2];

                    int currentSum = firstElement + secondElement + thirdElement + fourtElement + fifthElement
                        + sixthElement + seventhElement + eighthElement + ninthElement;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSquare = new int[,]
                        {
                            { firstElement, secondElement, thirdElement },
                            { fourtElement, fifthElement, sixthElement },
                            { seventhElement, eighthElement, ninthElement }
                        };
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < maxSquare.GetLength(0); row++)
            {
                for (int column = 0; column < maxSquare.GetLength(1); column++)
                {
                    int currentElement = maxSquare[row, column];

                    Console.Write(currentElement + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
