namespace UseYourChainsBuddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            string extractingPattern = @"<p>([\s\S]+?)<\/p>";

            StringBuilder encryptedText = new StringBuilder();

            MatchCollection matches = Regex.Matches(Console.ReadLine(), extractingPattern);

            foreach (Match match in matches)
            {
                encryptedText.Append(match.Groups[1].Value);
            }

            for (int i = 0; i < encryptedText.Length; i++)
            {
                if (char.IsDigit(encryptedText[i]))
                {
                    continue;
                }
                else if (!char.IsLower(encryptedText[i]))
                {
                    if (i > 0 && encryptedText[i - 1] == ' ')
                    {
                        encryptedText.Remove(i, 1);
                        i--;
                    }
                    else
                    {
                        encryptedText[i] = ' ';
                    }
                }
                else if (encryptedText[i] >= 'a' && encryptedText[i] <= 'm')
                {
                    encryptedText[i] = (char)(encryptedText[i] + 13);
                }
                else
                {
                    encryptedText[i] = (char)(encryptedText[i] - 13);
                }
            }

            Console.WriteLine(encryptedText);
        }
    }
}