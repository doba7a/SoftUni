namespace CondenseArrayToNumber
{
    using System;
    using System.Linq;

    public class CondenseArrayToNumber
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (arrayOfIntegers.Length > 1)
            {
                int[] condensedArray = new int[arrayOfIntegers.Length - 1];

                for (int i = 0; i < arrayOfIntegers.Length - 1; i++)
                {
                    condensedArray[i] = arrayOfIntegers[i] + arrayOfIntegers[i + 1];
                }

                arrayOfIntegers = condensedArray;
            }

            Console.WriteLine(arrayOfIntegers[0]);
        }
    }
}