namespace MatchHexadecimalNumbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchHexadecimalNumbers
    {
        public static void Main()
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";

            MatchCollection hexNumbersMatches = Regex.Matches(Console.ReadLine(), pattern);

            string[] hexNumbersMatched = hexNumbersMatches.Cast<Match>().Select(x => x.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(" ", hexNumbersMatched));
        }
    }
}