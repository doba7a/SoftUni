namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>(input.ToCharArray());

            Console.WriteLine(string.Join("", stack));
        }
    }
}
