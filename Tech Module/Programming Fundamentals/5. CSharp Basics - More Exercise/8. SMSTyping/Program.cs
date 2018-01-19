namespace SMSTyping
{
    using System;
    using System.Text;

    public class SMSTyping
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var givenNumber = Console.ReadLine();

                var maingDigit = givenNumber[0] - 48;

                if (maingDigit == 0)
                {
                    result.Append(" ");
                    continue;
                }

                var offset = (maingDigit - 2) * 3;

                if (maingDigit == 8 || maingDigit == 9)
                {
                    offset++;
                }

                var numberLength = givenNumber.Length;
                var letterIndex = offset + numberLength - 1;

                result.Append((char)(letterIndex + 97));
            }

            Console.WriteLine(result);
        }
    }
}