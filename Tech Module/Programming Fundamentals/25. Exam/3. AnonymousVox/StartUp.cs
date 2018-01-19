namespace AnonymousVox
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class AnonymousVox
    {
        public static void Main()
        {
            string encodingPattern = @"([A-Za-z]+)([\x00-\xFF]+)(\1)";

            string encodedText = Console.ReadLine();

            string[] values = Console.ReadLine().Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> placeholders = new List<string>();

            MatchCollection textMatches = Regex.Matches(encodedText, encodingPattern);

            int count = 0;

            foreach (Match match in textMatches)
            {
                int countOfSubstring = Regex.Matches(encodedText, match.Groups[2].Value).Count;

                if (countOfSubstring == 1)
                {
                    encodedText = encodedText.Replace(match.Groups[2].Value, values[count++]);
                }
                else
                {
                    int pos = encodedText.IndexOf(match.Groups[2].Value);

                    encodedText = encodedText.Substring(0, pos) + values[count++] + encodedText.Substring(pos + match.Groups[2].Value.Length);
                }
            }

            Console.WriteLine(encodedText);
        }
    }
}