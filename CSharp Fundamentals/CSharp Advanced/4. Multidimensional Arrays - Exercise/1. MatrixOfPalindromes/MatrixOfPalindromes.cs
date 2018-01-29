namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            string[,] matrix = new string[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string firstLetter = ((char)(row + 97)).ToString();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    string secondLetter = ((char)(row + column + 97)).ToString();

                    string palindrome = firstLetter + secondLetter + firstLetter + " ";

                    matrix[row, column] = palindrome;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }

                Console.WriteLine();
            }
        }
    }
}
