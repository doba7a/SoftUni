namespace RotateAndSum
{
    using System;
    using System.Linq;

    public class RotateAndSum
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotates = int.Parse(Console.ReadLine());

            int[] resultArray = new int[arrayOfIntegers.Length];

            while (rotates > 0)
            {
                int[] temporaryArray = new int[arrayOfIntegers.Length];

                temporaryArray[0] += arrayOfIntegers[arrayOfIntegers.Length - 1];
                for (int i = 0; i < arrayOfIntegers.Length - 1; i++)
                {
                    temporaryArray[i + 1] = arrayOfIntegers[i];
                }

                for (int i = 0; i < arrayOfIntegers.Length; i++)
                {
                    resultArray[i] += temporaryArray[i];
                }

                arrayOfIntegers = temporaryArray;

                rotates--;
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}