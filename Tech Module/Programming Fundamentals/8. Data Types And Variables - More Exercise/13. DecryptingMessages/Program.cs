namespace DecryptingMessages
{
    using System;
    using System.Text;

    public class DecryptingMessages
    {
        public static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                char currentCharGiven = char.Parse(Console.ReadLine());

                char outputChar = (char)(currentCharGiven + key);

                output.Append(outputChar);
            }

            Console.WriteLine(output);
        }
    }
}