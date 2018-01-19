namespace ExtractEmails
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            string pattern = @"(^|(?<=\s))([A-Za-z0-9]+(\.|-|_)?[A-Za-z0-9]+)@([A-Za-z]+(-)?[A-Za-z]+(\.{1}[A-Za-z]+(-)?[A-Za-z]+)+)";

            MatchCollection emailsMatches = Regex.Matches(Console.ReadLine(), pattern);

            string[] emailsMatched = emailsMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join($"{Environment.NewLine}", emailsMatched));
        }
    }
}