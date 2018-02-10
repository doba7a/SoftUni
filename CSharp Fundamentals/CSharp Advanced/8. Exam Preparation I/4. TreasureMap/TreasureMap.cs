namespace TreasureMap
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
        public static void Main()
        {
            string pattern = @"![^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?#|#[^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?!";

            Regex regex = new Regex(pattern);
            StringBuilder output = new StringBuilder();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int line = 0; line < numberOfInputs; line++)
            {
                string currentInput = Console.ReadLine();

                if (regex.IsMatch(currentInput))
                {
                    MatchCollection matches = regex.Matches(currentInput);

                    int mostInnerValidIndex = matches.Count / 2;
                    Match validMessage = matches[mostInnerValidIndex];

                    if (validMessage.ToString().StartsWith("!"))
                    {
                        string streetName = validMessage.Groups[1].Value;
                        string streetNumber = validMessage.Groups[2].Value;
                        string pass = validMessage.Groups[3].Value;

                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                    else
                    {
                        string streetName = validMessage.Groups[4].Value;
                        string streetNumber = validMessage.Groups[5].Value;
                        string pass = validMessage.Groups[6].Value;

                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
