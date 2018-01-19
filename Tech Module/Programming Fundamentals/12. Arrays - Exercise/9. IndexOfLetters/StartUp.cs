namespace IndexOfLetters
{
    using System;

    public class IndexOfLetters
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            if (word.Length > 0)
            {
                foreach (char character in word)
                {
                    Console.WriteLine($"{character} -> {character - 97}");
                }
            }
        }
    }
}