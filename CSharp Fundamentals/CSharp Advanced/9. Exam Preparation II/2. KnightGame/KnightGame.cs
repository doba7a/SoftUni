namespace KnightGame
{
    using System;
    using System.Collections.Generic;

    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class KnightGame
    {
        public static void Main()
        {
            char[,] boardMatrix = ReadMatrix();

            int totalKnightsRemoved = 0;

            bool knightRemoved = true;

            while (knightRemoved)
            {
                int maxAttacks = 0;
                Coordinates knightToRemove = new Coordinates();

                for (int row = 0; row < boardMatrix.GetLength(0); row++)
                {
                    for (int column = 0; column < boardMatrix.GetLength(1); column++)
                    {
                        if (boardMatrix[row, column] == 'K')
                        {
                            int currentKnightAttacks = CountOfPossibleAttacksForCurrentKnight(boardMatrix, row, column);

                            if (currentKnightAttacks > maxAttacks)
                            {
                                maxAttacks = currentKnightAttacks;
                                knightToRemove.Row = row;
                                knightToRemove.Column = column;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    boardMatrix[knightToRemove.Row, knightToRemove.Column] = '0';
                    totalKnightsRemoved++;
                }
                else
                {
                    knightRemoved = false;
                }
            }

            Console.WriteLine(totalKnightsRemoved);
        }

        public static char[,] ReadMatrix()
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());

            char[,] boardMatrix = new char[rowsAndColumns, rowsAndColumns];

            for (int row = 0; row < boardMatrix.GetLength(0); row++)
            {
                string currentRowData = Console.ReadLine();

                for (int column = 0; column < boardMatrix.GetLength(1); column++)
                {
                    boardMatrix[row, column] = currentRowData[column];
                }
            }

            return boardMatrix;
        }

        public static int CountOfPossibleAttacksForCurrentKnight(char[,] boardMatrix, int currentKnightRow, int currentKnightColumn)
        {
            int count = 0;

            List<Coordinates> possibleCoordinates = new List<Coordinates>();
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow + 2, Column = currentKnightColumn + 1 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow + 2, Column = currentKnightColumn - 1 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow - 2, Column = currentKnightColumn + 1 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow - 2, Column = currentKnightColumn - 1 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow + 1, Column = currentKnightColumn + 2 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow + 1, Column = currentKnightColumn - 2 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow - 1, Column = currentKnightColumn + 2 });
            possibleCoordinates.Add(new Coordinates() { Row = currentKnightRow - 1, Column = currentKnightColumn - 2 });

            foreach (Coordinates coordinates in possibleCoordinates)
            {
                if (coordinates.Row >= 0 && coordinates.Row < boardMatrix.GetLength(0)
                    && coordinates.Column >= 0 && coordinates.Column < boardMatrix.GetLength(1)
                    && boardMatrix[coordinates.Row, coordinates.Column] == 'K')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
