namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            int rotations = (int.Parse(new string(Console.ReadLine().Where(Char.IsDigit).ToArray())) / 90) % 4;

            List<string> textLines = new List<string>();
            string textLine = Console.ReadLine();

            while (textLine != "END")
            {
                textLines.Add(textLine);
                textLine = Console.ReadLine();
            }

            char[][] matrix = new char[textLines.Count][];
            int wordsLen = textLines.Max(r => r.Length);

            for (int row = 0; row < textLines.Count; row++)
            {
                matrix[row] = textLines[row].PadRight(wordsLen).ToCharArray();
            }

            for (int i = 0; i < rotations; i++)
            {
                matrix = Rotate(matrix);
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

        }

        public static char[,] CreateTheMatrix(List<string> textLines)
        {
            int rows = textLines.Count;
            int columns = textLines.OrderByDescending(x => x.Length).First().Length;

            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (column < textLines[row].Length)
                    {
                        matrix[row, column] = textLines[row][column];
                    }
                }
            }

            return matrix;
        }

        public static char[][] Rotate(char[][] matrix)
        {
            char[][] result = new char[matrix.Max(w => w.Length)][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[matrix.Length];

                for (int col = 0; col < result[row].Length; col++)
                {
                    result[row][col] = matrix[matrix.Length - 1 - col][row];
                }
            }

            return result;
        }
    }
}
