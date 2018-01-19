namespace LettersChangeNumbers
{
    using System;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;

            foreach (string token in inputData)
            {
                char firstLetter = char.Parse(token.Substring(0, 1));
                decimal number = decimal.Parse(token.Substring(1, token.Length - 2));
                char secondLetter = char.Parse(token.Substring(token.Length - 1));

                if (char.IsUpper(firstLetter))
                {
                    number /= FindCharPosition(firstLetter);
                }
                else
                {
                    number *= FindCharPosition(firstLetter);
                }

                if (char.IsUpper(secondLetter))
                {
                    number -= FindCharPosition(secondLetter);
                }
                else
                {
                    number += FindCharPosition(secondLetter);
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2}");
        }

        public static int FindCharPosition(char charGiven)
        {
            int position = char.Parse(charGiven.ToString().ToLower()) - 96;

            return position;
        }
    }
}