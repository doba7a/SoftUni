namespace CryptoBlockchain
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CryptoBlockchain
    {
        public static void Main()
        {
            StringBuilder inputString = new StringBuilder();

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                inputString.Append(Console.ReadLine());
            }

            Regex regex = new Regex(@"(\[|{)(.*?([0-9]{3,}).*?)(]|})");
            StringBuilder output = new StringBuilder();

            MatchCollection matches = regex.Matches(inputString.ToString());

            foreach (Match match in matches)
            {
                char openingBracket = match.ToString()[0];
                char closingBracket = match.ToString()[match.ToString().Length - 1];
                char[] digitsCount = match.Groups[3].Value.ToCharArray();

                if ((openingBracket == '[' && closingBracket == '}') 
                    || (openingBracket == '{' && closingBracket == ']') 
                    || digitsCount.Length % 3 != 0)
                {
                    continue;
                }

                int cryptoblockLength = match.Groups[0].Value.Length;

                for (int i = 0; i < digitsCount.Length; i += 3)
                {
                    string numberAsString = digitsCount[i].ToString() + digitsCount[i + 1].ToString() + digitsCount[i + 2].ToString();
                    int number = int.Parse(numberAsString);

                    int asciiCode = number - cryptoblockLength;

                    output.Append((char)asciiCode);
                }
            }

            Console.WriteLine(output);
        }
    }
}
