namespace KeyReplacer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class KeyReplacer
    {
        public static void Main()
        {
            string keyPattern = @"([A-Za-z]+)(?:\||<|\\)(?:\S)*(?:\||<|\\)([A-Za-z]+)";

            Match keyMatch = Regex.Match(Console.ReadLine(), keyPattern);

            string startKey = Regex.Escape(keyMatch.Groups[1].Value);
            string endKey = Regex.Escape(keyMatch.Groups[2].Value);

            string extractPattern = $@"{startKey}(?<word>.*?){endKey}";

            MatchCollection wordsCollection = Regex.Matches(Console.ReadLine(), extractPattern);

            StringBuilder resultStringBuilder = new StringBuilder();

            foreach (Match match in wordsCollection)
            {
                resultStringBuilder.Append(match.Groups["word"].Value);
            }

            Console.WriteLine(resultStringBuilder.Length == 0 ? "Empty result" : resultStringBuilder.ToString());
        }
    }
}