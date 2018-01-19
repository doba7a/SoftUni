namespace MakeAWord
{
    using System;
    using System.Text;

    public class MakeAWord
    {
        public static void Main()
        {
            int numberOfChars = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < numberOfChars; i++)
            {
                char givenChar = char.Parse(Console.ReadLine());
                output.Append(givenChar);
            }

            Console.WriteLine($"The word is: {output}");
        }
    }
}