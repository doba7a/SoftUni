namespace TwoXTwoEqualSquaresInMatrix
{
    using System;
    using System.Linq;

    public class TwoXTwoSquaresOfEqualChars
    {
        public static void Main()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRowData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = char.Parse(currentRowData[column]);
                }
            }

            int squaresOfEqualCharsCounter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    char firstChar = matrix[row, column];
                    char secondChar = matrix[row, column + 1];
                    char thirdChar = matrix[row + 1, column];
                    char fourthChar = matrix[row + 1, column + 1];

                    if (firstChar.Equals(secondChar) 
                        && secondChar.Equals(thirdChar) 
                        && thirdChar.Equals(fourthChar))
                    {
                        squaresOfEqualCharsCounter++;
                    }
                }
            }

            Console.WriteLine(squaresOfEqualCharsCounter);
        }
    }
}
