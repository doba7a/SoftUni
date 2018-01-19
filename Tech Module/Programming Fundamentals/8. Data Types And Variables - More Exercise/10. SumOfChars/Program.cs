using System;

namespace SumOfChars
{
    using System;

    public class SumOfChars
    {
        public static void Main()
        {
            int numberOfChars = int.Parse(Console.ReadLine());

            int outputSum = 0;

            for (int i = 0; i < numberOfChars; i++)
            {
                char givenChar = char.Parse(Console.ReadLine());
                outputSum += (int)givenChar;
            }

            Console.WriteLine($"The sum equals: {outputSum}");
        }
    }
}