namespace BalancedBrackets
{
    using System;

    public class BalancedBrackets
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            string lastBracket = string.Empty;
            int openingBrackets = 0;
            int closingBrackets = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentInput = Console.ReadLine();

                if (currentInput != "(" && currentInput != ")")
                {
                    continue;
                }

                if (currentInput == "(")
                {
                    openingBrackets++;
                }
                else
                {
                    closingBrackets++;
                }

                if (currentInput == lastBracket)
                {
                    Console.WriteLine("UNBALANCED");
                    Environment.Exit(1);
                }

                lastBracket = currentInput;
            }

            if (openingBrackets == closingBrackets)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}