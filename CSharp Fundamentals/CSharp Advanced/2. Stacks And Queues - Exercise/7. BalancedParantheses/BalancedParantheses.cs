namespace BalancedParantheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParantheses
    {
        public static void Main()
        {
            Stack<char> openingBrackets = new Stack<char>();
            Queue<char> closingBrackets = new Queue<char>();

            string input = Console.ReadLine();

            foreach (char paranthes in input)
            {
                if (paranthes == '[' || paranthes == '{' || paranthes == '(')
                {
                    openingBrackets.Push(paranthes);
                }
                else if (paranthes == ']' || paranthes == '}' || paranthes == ')')
                {
                    if (openingBrackets.Count == 0)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(1);
                    }

                    char lastOpeningBracket = openingBrackets.Pop();

                    if (lastOpeningBracket == '[' && paranthes != ']'
                        || lastOpeningBracket == '{' && paranthes != '}'
                        || lastOpeningBracket == '(' && paranthes != ')')
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(1);
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
