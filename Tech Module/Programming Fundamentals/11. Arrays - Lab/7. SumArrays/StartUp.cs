namespace SumArrays
{
    using System;
    using System.Linq;

    public class SumArrays
    {
        public static void Main()
        {
            int[] firstArrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxLength = Math.Max(firstArrayOfIntegers.Length, secondArrayOfIntegers.Length);

            int[] resultArray = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                int resultArrayInteger = firstArrayOfIntegers[i % firstArrayOfIntegers.Length] + secondArrayOfIntegers[i % secondArrayOfIntegers.Length];

                resultArray[i] = resultArrayInteger;
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}