namespace RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveMutantVampireBunnies
    {
        public static void Main()
        {
            char[,] matrix = ReadMatrix();

            string directions = Console.ReadLine();

            bool playerWon = false;
            int[] playerCoordinates = GetPlayerCoordinates(matrix);

            for (int i = 0; i < directions.Length; i++)
            {
                char currentMove = directions[i];

                playerWon = MovePlayer(matrix, currentMove, playerCoordinates);

                int[] tempPlayerCoordinates = GetPlayerCoordinates(matrix);
                if (!(tempPlayerCoordinates[0] == -1 && tempPlayerCoordinates[1] == -1))
                {
                    playerCoordinates = tempPlayerCoordinates;
                }

                SpreadBunnies(matrix);

                tempPlayerCoordinates = GetPlayerCoordinates(matrix);
                if (!(tempPlayerCoordinates[0] == -1 && tempPlayerCoordinates[1] == -1))
                {
                    playerCoordinates = tempPlayerCoordinates;
                }

                if ((tempPlayerCoordinates[0] == -1 && tempPlayerCoordinates[1] == -1) || playerWon)
                {
                    break;
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

            if (playerWon)
            {
                Console.WriteLine($"won: {string.Join(" ", playerCoordinates)}");
            }
            else
            {
                Console.WriteLine($"dead: {string.Join(" ", playerCoordinates)}");
            }
        }

        public static char[,] ReadMatrix()
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
                string currentRowData = Console.ReadLine();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentRowData[column];
                }
            }

            return matrix;
        }

        public static int[] GetPlayerCoordinates(char[,] matrix)
        {
            int[] coordinates = new int[2] { -1, -1 };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int currentElement = matrix[row, column];

                    if (currentElement == 'P')
                    {
                        coordinates[0] = row;
                        coordinates[1] = column;

                        return coordinates;
                    }
                }
            }

            return coordinates;
        }

        public static bool MovePlayer(char[,] matrix, char currentMove, int[] playerCoordinates)
        {
            int playerRow = playerCoordinates[0];
            int playerColumn = playerCoordinates[1];

            matrix[playerRow, playerColumn] = '.';

            switch (currentMove)
            {
                case 'U':
                    int playerRowAfterMovingUp = playerRow - 1;

                    if (playerRowAfterMovingUp < 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (matrix[playerRowAfterMovingUp, playerColumn] == 'B')
                        {
                            playerCoordinates[0] = playerRowAfterMovingUp;
                            break;
                        }
                        matrix[playerRowAfterMovingUp, playerColumn] = 'P';
                    }

                    break;

                case 'D':
                    int playerRowAfterMovingDown = playerRow + 1;

                    if (playerRowAfterMovingDown > matrix.GetLength(0) - 1)
                    {
                        return true;
                    }
                    else
                    {
                        if (matrix[playerRowAfterMovingDown, playerColumn] == 'B')
                        {
                            playerCoordinates[0] = playerRowAfterMovingDown;
                            break;
                        }
                        matrix[playerRowAfterMovingDown, playerColumn] = 'P';
                    }

                    break;

                case 'L':
                    int playerColumnAfterMovingLeft = playerColumn - 1;

                    if (playerColumnAfterMovingLeft < 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (matrix[playerRow, playerColumnAfterMovingLeft] == 'B')
                        {
                            playerCoordinates[1] = playerColumnAfterMovingLeft;
                            break;
                        }
                        matrix[playerRow, playerColumnAfterMovingLeft] = 'P';
                    }

                    break;

                case 'R':
                    int playerColumnAfterMovingRight = playerColumn + 1;

                    if (playerColumnAfterMovingRight > matrix.GetLength(1) - 1)
                    {
                        return true;
                    }
                    else
                    {
                        if (matrix[playerRow, playerColumnAfterMovingRight] == 'B')
                        {
                            playerCoordinates[1] = playerColumnAfterMovingRight;
                            break;
                        }
                        matrix[playerRow, playerColumnAfterMovingRight] = 'P';
                    }

                    break;
            }

            return false;
        }

        public static void SpreadBunnies(char[,] matrix)
        {
            List<int> bunniesCoordinates = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    char currentElement = matrix[row, column];

                    if (currentElement == 'B')
                    {
                        bunniesCoordinates.Add(row);
                        bunniesCoordinates.Add(column);
                    }
                }
            }

            for (int i = 0; i < bunniesCoordinates.Count - 1; i += 2)
            {
                int row = bunniesCoordinates[i];
                int column = bunniesCoordinates[i + 1];

                matrix[Math.Max(0, row - 1), column] = 'B';
                matrix[Math.Min(matrix.GetLength(0) - 1, row + 1), column] = 'B';

                matrix[row, Math.Max(0, column - 1)] = 'B';
                matrix[row, Math.Min(matrix.GetLength(1) - 1, column + 1)] = 'B';
            }
        }
    }
}
