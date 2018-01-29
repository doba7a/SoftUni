namespace LegoBlocks
{
    using System;

    public class LegoBlocks
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] firstJaggedArray = ReadJaggedArray(rows);
            string[][] secondJaggedArray = ReadJaggedArray(rows);

            int firstRowCells = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
            int totalCells = firstRowCells;

            bool fittingArrays = true;

            for (int row = 1; row < rows; row++)
            {
                int nextRowCells = firstJaggedArray[row].Length + secondJaggedArray[row].Length;
                totalCells += nextRowCells;

                if (nextRowCells != firstRowCells)
                {
                    fittingArrays = false;
                }
            }

            if (fittingArrays)
            {
                for (int row = 0; row < rows; row++)
                {
                    Array.Reverse(secondJaggedArray[row]);

                    Console.WriteLine($"[{string.Join(", ", firstJaggedArray[row])}, {string.Join(", ", secondJaggedArray[row])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }

        public static string[][] ReadJaggedArray(int rows)
        {
            string[][] JaggedArray = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                JaggedArray[i] = currentRow;
            }

            return JaggedArray;
        }
    }
}
