namespace MatchPhoneNumber
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            string pattern = @"( |^)\+359( |-)2\2\d{3}\2\d{4}\b";

            MatchCollection numbersMatches = Regex.Matches(Console.ReadLine(), pattern);

            string[] numbersMatched = numbersMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", numbersMatched));
        }
    }
}