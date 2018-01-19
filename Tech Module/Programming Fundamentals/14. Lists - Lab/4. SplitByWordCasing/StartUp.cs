namespace SplitByWordCasing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SplitByWordCasing
    {
        public static void Main()
        {
            List<string> listOFWords = Console.ReadLine()
                .Split(new[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> listOfLowercaseWords = new List<string>();
            List<string> listOfMixedcaseWords = new List<string>();
            List<string> listOfUppercaseWords = new List<string>();

            foreach (string word in listOFWords)
            {
                string wordToCheck = word;
                int lowerCaseChars = 0;
                int upperCaseChars = 0;

                foreach (var character in word)
                {
                    if (char.IsLower(character))
                    {
                        lowerCaseChars++;
                    }
                    else if (char.IsUpper(character))
                    {
                        upperCaseChars++;
                    }
                }

                if (lowerCaseChars == word.Length)
                {
                    listOfLowercaseWords.Add(word);
                }
                else if (upperCaseChars == word.Length)
                {
                    listOfUppercaseWords.Add(word);
                }
                else
                {
                    listOfMixedcaseWords.Add(word);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", listOfLowercaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", listOfMixedcaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", listOfUppercaseWords)}");
        }
    }
}