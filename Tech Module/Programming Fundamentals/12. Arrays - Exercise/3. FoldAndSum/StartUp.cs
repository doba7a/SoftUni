namespace FoldAndSum
{
    using System;
    using System.Linq;

    public class FoldAndSum
    {
        public static void Main()
        {
            int[] initialArrayOfInts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = initialArrayOfInts.Length;

            int[] firstRowFirstPart = initialArrayOfInts.Take(length / 4).ToArray();
            Array.Reverse(firstRowFirstPart);

            int[] firstRowSecondPart = initialArrayOfInts.Skip(length / 4 * 3).ToArray();
            Array.Reverse(firstRowSecondPart);

            int[] firstRow = firstRowFirstPart.Concat(firstRowSecondPart).ToArray();

            int[] secondRow = initialArrayOfInts.Skip(length / 4).Take(length / 2).ToArray();

            int[] resultArray = new int[length / 2];

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}