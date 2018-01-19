namespace ReverseString
{
    using System;

    public class ReverseString
    {
        public static void Main()
        {
            char[] inputStringAsCharArray = Console.ReadLine().ToCharArray();

            string resultString = string.Empty;

            for (int i = inputStringAsCharArray.Length - 1; i >= 0; i--)
            {
                resultString += inputStringAsCharArray[i];
            }

            Console.WriteLine(resultString.ToString());
        }
    }
}