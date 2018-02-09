namespace Regeh
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Regex pattern = new Regex(@"\[[^\[\]\s]+<(\d+)REGEH(\d+)>[^\[\]\s]+\]");
            MatchCollection matches = pattern.Matches(inputString);

            int sum = 0;
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                int currentIndex = int.Parse(match.Groups[1].ToString());
                sum += currentIndex;

                sb.Append(inputString[sum % (inputString.Length - 1)]);

                currentIndex = int.Parse(match.Groups[2].ToString());
                sum += currentIndex;

                sb.Append(inputString[sum % (inputString.Length - 1)]);

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
