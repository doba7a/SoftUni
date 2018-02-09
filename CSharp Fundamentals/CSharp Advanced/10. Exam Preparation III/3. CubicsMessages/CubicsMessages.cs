namespace CubicsMessages
{
    using System;
    using System.Text.RegularExpressions;

    public class CubicsMessages
    {
        public static void Main()
        {
            Regex regex = new Regex(@"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$");

            string currentInput = Console.ReadLine();

            while (currentInput != "Over!")
            {
                int messageLength = int.Parse(Console.ReadLine());

                if (regex.IsMatch(currentInput))
                {
                    Match messageMatch = regex.Match(currentInput);

                    if (messageMatch.Groups[2].Length != messageLength)
                    {
                        currentInput = Console.ReadLine();
                        continue;
                    }

                    string message = messageMatch.Groups[2].ToString();
                    string verificationCode = GetVerificationCode(messageMatch, message);

                    Console.WriteLine($"{message} == {verificationCode}");
                }

                currentInput = Console.ReadLine();
            }
        }

        public static string GetVerificationCode(Match messageMatch, string message)
        {
            string indexes = messageMatch.Groups[1].ToString() + messageMatch.Groups[3].ToString();
            string verificationCode = string.Empty;

            foreach (char index in indexes)
            {
                if (char.IsDigit(index))
                {
                    int currentIndex = int.Parse(index.ToString());

                    if (currentIndex < message.Length)
                    {
                        verificationCode += message[currentIndex];
                    }
                    else
                    {
                        verificationCode += " ";
                    }
                }
            }

            return verificationCode;
        }
    }
}
