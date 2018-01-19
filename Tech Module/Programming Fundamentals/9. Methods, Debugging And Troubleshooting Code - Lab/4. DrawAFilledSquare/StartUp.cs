namespace drawAFilledSquare
{
    using System;

    public class drawAFilledSquare
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            printTopOrBottomRow(n);
            printSquareBody(n);
            printTopOrBottomRow(n);
        }

        public static void printTopOrBottomRow(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }

        public static void printSquareBody(int n)
        {
            for (int i = 1; i < n - 1; i++)
            {
                Console.Write('-');

                for (int j = 1; j < n; j++)
                {
                    Console.Write('\\');
                    Console.Write('/');
                }

                Console.WriteLine('-');
            }
        }
    }
}