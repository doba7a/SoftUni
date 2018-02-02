namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> openingBracketsIndexes = new Stack<int>();

            for (int counter = 0; counter < input.Length; counter++)
            {
                if (input[counter] == '(')
                {
                    openingBracketsIndexes.Push(counter);
                }
                else if (input[counter] == ')')
                {
                    int indexOfLastOpeningBracket = openingBracketsIndexes.Pop();
                    int length = counter - indexOfLastOpeningBracket + 1;

                    string output = input.Substring(indexOfLastOpeningBracket, length);

                    Console.WriteLine(output);
                }
            }
        }
    }
}
