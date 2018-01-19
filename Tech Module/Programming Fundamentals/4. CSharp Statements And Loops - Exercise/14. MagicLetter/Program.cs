namespace MagicLetter
{
    using System;

    public class MagicLetter
    {
        public static void Main()
        {
            var firstChar = char.Parse(Console.ReadLine());
            var secondChar = char.Parse(Console.ReadLine());
            var invalidChar = Console.ReadLine();

            for (char i = firstChar; i <= secondChar; i++)
            {
                for (char j = firstChar; j <= secondChar; j++)
                {
                    for (char k = firstChar; k <= secondChar; k++)
                    {
                        var letter = $"{i}{j}{k}";

                        if (!letter.Contains(invalidChar))
                        {
                            Console.Write(letter + " ");
                        }
                    }
                }
            }
        }
    }
}