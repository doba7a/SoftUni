namespace LargestCommonEnd
{
    using System;
    using System.Linq;

    public class LargestCommonEnd
    {
        public static void Main()
        {
            string[] firstArrayOfWords = Console.ReadLine().Split(' ').ToArray();
            string[] secondArrayOfWords = Console.ReadLine().Split(' ').ToArray();

            int countFromStart = countCommonEnd(firstArrayOfWords, secondArrayOfWords);

            Array.Reverse(firstArrayOfWords);
            Array.Reverse(secondArrayOfWords);

            int countFromEnd = countCommonEnd(firstArrayOfWords, secondArrayOfWords);

            if (countFromStart >= countFromEnd)
            {
                Console.WriteLine(countFromStart);
            }
            else
            {
                Console.WriteLine(countFromEnd);
            }
        }

        public static int countCommonEnd(string[] firstArray, string[] secondArray)
        {
            int minLength = Math.Min(firstArray.Length, secondArray.Length);

            int count = 0;

            for (int i = 0; i < minLength; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}