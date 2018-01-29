namespace TargetPractice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            char[,] matrix = ReadTheMatrix();

            MatrixAfterTheShot(matrix);

            RearrangeTheMatrix(matrix);

            PrintResultMatrix(matrix);
        }

        public static char[,] ReadTheMatrix()
        {
            int[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = inputData[0];
            int columns = inputData[1];

            char[,] matrix = new char[rows, columns];

            string snakeString = Console.ReadLine();

            bool goLeft = true;
            int charCounter = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (goLeft)
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        matrix[row, column] = snakeString[charCounter++];

                        if (charCounter > snakeString.Length - 1)
                        {
                            charCounter = 0;
                        }
                    }

                    goLeft = false;
                }
                else
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        matrix[row, column] = snakeString[charCounter++];

                        if (charCounter > snakeString.Length - 1)
                        {
                            charCounter = 0;
                        }
                    }

                    goLeft = true;
                }
            }

            return matrix;
        }

        public static void MatrixAfterTheShot(char[,] matrix)
        {
            int[] shotData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int shotRow = shotData[0];
            int shotColumn = shotData[1];
            int shotRadius = shotData[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (Math.Pow((row - shotRow), 2) + Math.Pow((column - shotColumn), 2) <= Math.Pow(shotRadius, 2))
                    {
                        matrix[row, column] = ' ';
                    }
                }
            }
        }

        public static void RearrangeTheMatrix(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                {
                    char currentElement = matrix[row, column];

                    if (currentElement == ' ')
                    {
                        for (int currentRow = row - 1; currentRow >= 0; currentRow--)
                        {
                            char tempElement = matrix[currentRow, column];

                            if (tempElement != ' ')
                            {
                                matrix[row, column] = tempElement;
                                matrix[currentRow, column] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static void PrintResultMatrix(char[,] matrix)
        {
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
