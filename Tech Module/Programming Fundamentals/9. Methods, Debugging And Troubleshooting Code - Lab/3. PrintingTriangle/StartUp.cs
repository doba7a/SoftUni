namespace printingTriangle
{
    using System;

    public class printingTriangle
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                printTriangle(i);
            }

            for (int i = n; i >= 1; i--)
            {
                printTriangle(i);
            }
        }

        public static void printTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
