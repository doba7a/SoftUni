namespace MatchDates
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchDates
    {
        public static void Main()
        {
            string pattern = @"\b(\d{2})(\/|-|.)([A-Z]{1}[a-z]{2})(\2)(\d{4})\b";

            MatchCollection datesMatches = Regex.Matches(Console.ReadLine(), pattern);

            foreach (Match date in datesMatches)
            {
                string days = date.Groups[1].Value;
                string months = date.Groups[3].Value;
                string years = date.Groups[5].Value;

                Console.WriteLine($"Day: {days}, Month: {months}, Year: {years}");
            }
        }
    }
}