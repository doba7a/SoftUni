using System;
using System.Collections.Generic;
using System.Linq;

public class Sneaking
{
    public static void Main()
    {
        char[][] jagged = ReadJagged();

        char[] directions = Console.ReadLine().ToCharArray();
        int directionsCounter = 0;

        while (true)
        {
            MoveEnemies(jagged);

            CheckIfEnemyKillsSam(jagged);

            MoveSam(jagged, directions[directionsCounter++]);

            CheckIfSamKillsNikoladze(jagged);
        }
    }

    public static char[][] ReadJagged()
    {
        int rows = int.Parse(Console.ReadLine());

        char[][] jagged = new char[rows][];

        for (int i = 0; i < rows; i++)
        {
            char[] currentRow = Console.ReadLine()
                .ToCharArray();

            jagged[i] = currentRow;
        }

        return jagged;
    }

    public static void MoveEnemies(char[][] jagged)
    {
        List<Coordinates> enemies = GetEnemyCoordinates(jagged);

        foreach (Coordinates enemy in enemies)
        {
            int currentEnemyRow = enemy.Row;
            int currentEnemyColumn = enemy.Column;

            if (jagged[currentEnemyRow][currentEnemyColumn] == 'b')
            {
                if (currentEnemyColumn + 1 < jagged[currentEnemyRow].Length)
                {
                    jagged[currentEnemyRow][currentEnemyColumn] = '.';
                    jagged[currentEnemyRow][currentEnemyColumn + 1] = 'b';
                }
                else
                {
                    jagged[currentEnemyRow][currentEnemyColumn] = 'd';
                }
            }
            else if (jagged[currentEnemyRow][currentEnemyColumn] == 'd')
            {
                if (currentEnemyColumn - 1 >= 0)
                {
                    jagged[currentEnemyRow][currentEnemyColumn] = '.';
                    jagged[currentEnemyRow][currentEnemyColumn - 1] = 'd';
                }
                else
                {
                    jagged[currentEnemyRow][currentEnemyColumn] = 'b';
                }
            }
        }
    }

    public static void CheckIfEnemyKillsSam(char[][] jagged)
    {
        List<Coordinates> enemies = GetEnemyCoordinates(jagged);

        foreach (Coordinates enemy in enemies)
        {
            int currentEnemyRow = enemy.Row;
            int currentEnemyColumn = enemy.Column;

            if (jagged[currentEnemyRow][currentEnemyColumn] == 'b')
            {
                char[] enemySight = jagged[currentEnemyRow].Skip(currentEnemyColumn + 1).ToArray();

                if (enemySight.Contains('S'))
                {
                    Coordinates samCoordinates = FindSam(jagged, currentEnemyRow);

                    jagged[samCoordinates.Row][samCoordinates.Column] = 'X';

                    Console.WriteLine($"Sam died at {samCoordinates.Row}, {samCoordinates.Column}");

                    PrintJagged(jagged);

                    Environment.Exit(0);
                }
            }
            else if (jagged[currentEnemyRow][currentEnemyColumn] == 'd')
            {
                char[] enemySight = jagged[currentEnemyRow].Take(currentEnemyColumn).ToArray();

                if (enemySight.Contains('S'))
                {
                    Coordinates samCoordinates = FindSam(jagged, currentEnemyRow);

                    jagged[samCoordinates.Row][samCoordinates.Column] = 'X';

                    Console.WriteLine($"Sam died at {samCoordinates.Row}, {samCoordinates.Column}");

                    PrintJagged(jagged);

                    Environment.Exit(0);
                }
            }
        }
    }

    public static void MoveSam(char[][] jagged, char direction)
    {
        if (direction == 'W')
        {
            return;
        }

        Coordinates samCoordinates = FindSam(jagged, -1);

        jagged[samCoordinates.Row][samCoordinates.Column] = '.';

        switch (direction)
        {
            case 'U':
                jagged[samCoordinates.Row - 1][samCoordinates.Column] = 'S';
                break;
            case 'D':
                jagged[samCoordinates.Row + 1][samCoordinates.Column] = 'S';
                break;
            case 'L':
                jagged[samCoordinates.Row][samCoordinates.Column - 1] = 'S';
                break;
            case 'R':
                jagged[samCoordinates.Row][samCoordinates.Column + 1] = 'S';
                break;
        }
    }

    public static void CheckIfSamKillsNikoladze(char[][] jagged)
    {
        Coordinates samCoordinates = FindSam(jagged, -1);
        Coordinates nikoladzeCoordinates = FindNikoladze(jagged);

        if (samCoordinates.Row == nikoladzeCoordinates.Row)
        {
            jagged[nikoladzeCoordinates.Row][nikoladzeCoordinates.Column] = 'X';

            Console.WriteLine("Nikoladze killed!");

            PrintJagged(jagged);

            Environment.Exit(0);
        }
    }

    public static List<Coordinates> GetEnemyCoordinates(char[][] jagged)
    {
        List<Coordinates> enemies = new List<Coordinates>();

        for (int row = 0; row < jagged.Length; row++)
        {
            for (int column = 0; column < jagged[row].Length; column++)
            {
                if (jagged[row][column] == 'b' || jagged[row][column] == 'd')
                {
                    Coordinates currentEnemy = new Coordinates()
                    {
                        Row = row,
                        Column = column
                    };

                    enemies.Add(currentEnemy);
                }
            }
        }

        return enemies;
    }

    public static Coordinates FindNikoladze(char[][] jagged)
    {
        Coordinates nikoladzeCoordinates = new Coordinates();

        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                if (jagged[i][j] == 'N')
                {
                    nikoladzeCoordinates.Row = i;
                    nikoladzeCoordinates.Column = j;

                    return nikoladzeCoordinates;
                }
            }
        }

        return nikoladzeCoordinates;
    }

    public static Coordinates FindSam(char[][] jagged, int row)
    {
        Coordinates samCoordinates = new Coordinates();

        if (row > -1)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                if (jagged[row][i] == 'S')
                {
                    samCoordinates.Row = row;
                    samCoordinates.Column = i;

                    return samCoordinates;
                }
            }
        }
        else
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (jagged[i][j] == 'S')
                    {
                        samCoordinates.Row = i;
                        samCoordinates.Column = j;

                        return samCoordinates;
                    }
                }
            }
        }

        return samCoordinates;
    }

    public static void PrintJagged(char[][] jagged)
    {
        for (int row = 0; row < jagged.Length; row++)
        {
            for (int column = 0; column < jagged[row].Length; column++)
            {
                Console.Write(jagged[row][column]);
            }

            Console.WriteLine();
        }
    }
}
