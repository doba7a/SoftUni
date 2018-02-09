namespace DangerousFloor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class DangerousFloor
    {
        public static void Main()
        {
            char[,] boardMatrix = ReadMatrix();

            string currentCommand = Console.ReadLine();

            while (currentCommand != "END")
            {
                char pieceToMove = currentCommand[0];
                int initialPositionRow = int.Parse(currentCommand[1].ToString());
                int initialPositionColumn = int.Parse(currentCommand[2].ToString());
                int finalPositionRow = int.Parse(currentCommand[4].ToString());
                int finalPoisionColumn = int.Parse(currentCommand[5].ToString());

                if (boardMatrix[initialPositionRow, initialPositionColumn] != pieceToMove)
                {
                    Console.WriteLine("There is no such a piece!");
                    currentCommand = Console.ReadLine();
                    continue;
                }

                if (pieceToMove == 'K')
                {
                    MoveKing(boardMatrix, initialPositionRow, initialPositionColumn, finalPositionRow, finalPoisionColumn);
                }
                else if (pieceToMove == 'R')
                {
                    MoveRook(boardMatrix, initialPositionRow, initialPositionColumn, finalPositionRow, finalPoisionColumn);
                }
                else if (pieceToMove == 'B')
                {
                    MoveBishop(boardMatrix, initialPositionRow, initialPositionColumn, finalPositionRow, finalPoisionColumn);
                }
                else if (pieceToMove == 'Q')
                {
                    MoveQueen(boardMatrix, initialPositionRow, initialPositionColumn, finalPositionRow, finalPoisionColumn);
                }
                else if (pieceToMove == 'P')
                {
                    MovePawn(boardMatrix, initialPositionRow, initialPositionColumn, finalPositionRow, finalPoisionColumn);
                }

                currentCommand = Console.ReadLine();
            }
        }

        public static char[,] ReadMatrix()
        {
            char[,] boardMatrix = new char[8, 8];

            for (int row = 0; row < boardMatrix.GetLength(0); row++)
            {
                char[] currentRowData = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int column = 0; column < boardMatrix.GetLength(1); column++)
                {
                    boardMatrix[row, column] = currentRowData[column];
                }
            }

            return boardMatrix;
        }

        public static bool CheckMoveValidity(List<Coordinates> validMoves, int finalRow, int finalColumn)
        {
            if (finalRow < 0 || finalRow >= 8 || finalColumn < 0 || finalColumn >= 8)
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }

            bool validMove = false;

            foreach (Coordinates validCoordinates in validMoves)
            {
                int currentRow = validCoordinates.Row;
                int currentColumn = validCoordinates.Column;

                if (currentRow == finalRow && currentColumn == finalColumn)
                {
                    validMove = true;
                }
            }

            if (!validMove)
            {
                Console.WriteLine("Invalid move!");
                return false;
            }

            return true;
        }

        public static void MoveKing(char[,] boardMatrix, int initialRow, int initialColumn, int finalRow, int finalColumn)
        {
            List<Coordinates> validMoves = validKingMoves(boardMatrix, initialRow, initialColumn);

            bool validMove = CheckMoveValidity(validMoves, finalRow, finalColumn);

            if (validMove)
            {
                boardMatrix[initialRow, initialColumn] = 'x';
                boardMatrix[finalRow, finalColumn] = 'K';
            }
        }

        public static List<Coordinates> validKingMoves(char[,] boardMatrix, int initialRow, int initialColumn)
        {
            int startingRow = initialRow - 1;
            int endingRow = initialRow + 1;
            int startingColumn = initialColumn - 1;
            int endingColumn = initialColumn + 1;

            List<Coordinates> validMoves = new List<Coordinates>();

            for (int row = startingRow; row <= endingRow; row++)
            {
                for (int column = startingColumn; column <= endingColumn; column++)
                {
                    if (row >= 0 && row < 8 && column >= 0 && column < 8 && boardMatrix[row, column] == 'x')
                    {
                        Coordinates validMoveCoordinates = new Coordinates
                        {
                            Row = row,
                            Column = column
                        };

                        validMoves.Add(validMoveCoordinates);
                    }
                }
            }

            return validMoves;
        }

        public static void MoveRook(char[,] boardMatrix, int initialRow, int initialColumn, int finalRow, int finalColumn)
        {
            List<Coordinates> validMoves = validRookMoves(boardMatrix, initialRow, initialColumn);

            bool validMove = CheckMoveValidity(validMoves, finalRow, finalColumn);

            if (validMove)
            {
                boardMatrix[initialRow, initialColumn] = 'x';
                boardMatrix[finalRow, finalColumn] = 'R';
            }
        }

        public static List<Coordinates> validRookMoves(char[,] boardMatrix, int initialRow, int initialColumn)
        {
            List<Coordinates> validMoves = new List<Coordinates>();

            for (int column = initialColumn - 1; column >= 0; column--)
            {
                if (boardMatrix[initialRow, column] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = initialRow,
                        Column = column
                    };

                    validMoves.Add(validMoveCoordinates);
                }
                else
                {
                    break;
                }
            }

            for (int column = initialColumn + 1; column < 8; column++)
            {
                if (boardMatrix[initialRow, column] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = initialRow,
                        Column = column
                    };

                    validMoves.Add(validMoveCoordinates);
                }
                else
                {
                    break;
                }
            }

            for (int row = initialRow - 1; row >= 0; row--)
            {
                if (boardMatrix[row, initialColumn] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = row,
                        Column = initialColumn
                    };

                    validMoves.Add(validMoveCoordinates);
                }
                else
                {
                    break;
                }
            }

            for (int row = initialRow + 1; row < 8; row++)
            {
                if (boardMatrix[row, initialColumn] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = row,
                        Column = initialColumn
                    };

                    validMoves.Add(validMoveCoordinates);
                }
                else
                {
                    break;
                }
            }

            return validMoves;
        }

        public static void MoveBishop(char[,] boardMatrix, int initialRow, int initialColumn, int finalRow, int finalColumn)
        {
            List<Coordinates> validMoves = validBishopMoves(boardMatrix, initialRow, initialColumn);

            bool validMove = CheckMoveValidity(validMoves, finalRow, finalColumn);

            if (validMove)
            {
                boardMatrix[initialRow, initialColumn] = 'x';
                boardMatrix[finalRow, finalColumn] = 'B';
            }
        }

        public static List<Coordinates> validBishopMoves(char[,] boardMatrix, int initialRow, int initialColumn)
        {
            List<Coordinates> validMoves = new List<Coordinates>();

            int tempRowCounter = initialRow - 1;
            int tempColumnCounter = initialColumn - 1;

            while (tempRowCounter >= 0 && tempColumnCounter >= 0)
            {
                if (boardMatrix[tempRowCounter, tempColumnCounter] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = tempRowCounter,
                        Column = tempColumnCounter
                    };

                    validMoves.Add(validMoveCoordinates);

                    tempRowCounter--;
                    tempColumnCounter--;
                }
                else
                {
                    break;
                }
            }

            tempRowCounter = initialRow + 1;
            tempColumnCounter = initialColumn + 1;

            while (tempRowCounter < 8 && tempColumnCounter < 8)
            {
                if (boardMatrix[tempRowCounter, tempColumnCounter] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = tempRowCounter,
                        Column = tempColumnCounter
                    };

                    validMoves.Add(validMoveCoordinates);

                    tempRowCounter++;
                    tempColumnCounter++;
                }
                else
                {
                    break;
                }
            }

            tempRowCounter = initialRow - 1;
            tempColumnCounter = initialColumn + 1;

            while (tempRowCounter >= 0 && tempColumnCounter < 8)
            {
                if (boardMatrix[tempRowCounter, tempColumnCounter] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = tempRowCounter,
                        Column = tempColumnCounter
                    };

                    validMoves.Add(validMoveCoordinates);

                    tempRowCounter--;
                    tempColumnCounter++;
                }
                else
                {
                    break;
                }
            }

            tempRowCounter = initialRow + 1;
            tempColumnCounter = initialColumn - 1;

            while (tempRowCounter < 8 && tempColumnCounter >= 0)
            {
                if (boardMatrix[tempRowCounter, tempColumnCounter] == 'x')
                {
                    Coordinates validMoveCoordinates = new Coordinates
                    {
                        Row = tempRowCounter,
                        Column = tempColumnCounter
                    };

                    validMoves.Add(validMoveCoordinates);

                    tempRowCounter++;
                    tempColumnCounter--;
                }
                else
                {
                    break;
                }
            }

            return validMoves;
        }

        public static void MoveQueen(char[,] boardMatrix, int initialRow, int initialColumn, int finalRow, int finalColumn)
        {
            List<Coordinates> validHorizontalAndVerticalMoves = validRookMoves(boardMatrix, initialRow, initialColumn);
            List<Coordinates> validDiagonalMoves = validBishopMoves(boardMatrix, initialRow, initialColumn);

            List<Coordinates> validMoves = validHorizontalAndVerticalMoves.Concat(validDiagonalMoves).ToList();

            bool validMove = CheckMoveValidity(validMoves, finalRow, finalColumn);

            if (validMove)
            {
                boardMatrix[initialRow, initialColumn] = 'x';
                boardMatrix[finalRow, finalColumn] = 'Q';
            }
        }

        public static void MovePawn(char[,] boardMatrix, int initialRow, int initialColumn, int finalRow, int finalColumn)
        {
            if (finalRow < 0 || finalRow > 8 || finalColumn < 0 || finalRow > 8)
            {
                Console.WriteLine("Move go out of board!");
                return;
            }

            if (initialRow - 1 != finalRow)
            {
                Console.WriteLine("Invalid move!");
                return;
            }

            boardMatrix[initialRow, initialColumn] = 'x';
            boardMatrix[finalRow, finalColumn] = 'P';
        }
    }
}
