namespace GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] jagged = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                int[] currentGroup = inputNumbers.Where(x => Math.Abs(x % 3) == i).ToArray();

                jagged[i] = currentGroup;
            }

            foreach (Array remainderGroup in jagged)
            {
                foreach (int value in remainderGroup)
                {
                    Console.Write(value + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
