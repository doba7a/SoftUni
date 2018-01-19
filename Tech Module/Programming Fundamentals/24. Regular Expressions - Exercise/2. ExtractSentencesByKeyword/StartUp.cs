namespace ExtractSentencesByKeyword
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractSentencesByKeyword
    {
        public static void Main()
        {
            string keywordGiven = $@"\b{Console.ReadLine()}\b";

            string[] arrayOfSentences = Console.ReadLine().Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string currentSentence in arrayOfSentences)
            {
                if (Regex.IsMatch(currentSentence, keywordGiven))
                {
                    Console.WriteLine(currentSentence.Trim());
                }
            }
        }
    }
}