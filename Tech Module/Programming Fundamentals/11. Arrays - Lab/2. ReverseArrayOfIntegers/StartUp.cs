namespace ReverseArrayOfIntegers
{
    using System;

    public class ReverseArrayOfIntegers
    {
        public static void Main()
        {
            int arrayLength = int.Parse(Console.ReadLine());

            int[] arrayOfInts = new int[arrayLength];

            for (int i = 0; i < arrayOfInts.Length; i++)
            {
                arrayOfInts[i] = int.Parse(Console.ReadLine());
            }

            Array.Reverse(arrayOfInts);

            Console.WriteLine(string.Join(" ", arrayOfInts));
        }
    }
}