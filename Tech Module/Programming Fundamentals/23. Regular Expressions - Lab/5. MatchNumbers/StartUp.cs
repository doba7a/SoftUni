namespace MatchNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchNumbers
    {
        public static void Main()
        {
            string pattern = @"(^|(?<=\s))(-)?(\d)*(\.)?(\d)*($|(?=\s))";

            MatchCollection numbersMatches = Regex.Matches(Console.ReadLine(), pattern);

            string[] numbersMatched = numbersMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(" ", numbersMatched));
        }
    }
}