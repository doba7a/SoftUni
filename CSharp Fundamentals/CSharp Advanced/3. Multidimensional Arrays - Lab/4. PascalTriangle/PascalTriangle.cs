namespace PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrixPascal = new long[n][];

            if (n == 0)
            {
                Environment.Exit(0);
            }

            for (int row = 0; row < n; row++)
            {
                matrixPascal[row] = new long[row + 1];

                matrixPascal[row][0] = 1;

                Console.Write(matrixPascal[row][0] + " ");

                for (int column = 1; column <= row; column++)
                {
                    long firstElement = matrixPascal[row - 1][column - 1];

                    long secondElement;

                    try
                    {
                        secondElement = matrixPascal[row - 1][column];
                    }
                    catch (Exception)
                    {
                        secondElement = 0;
                    }

                    matrixPascal[row][column] = firstElement + secondElement;

                    Console.Write(matrixPascal[row][column] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
