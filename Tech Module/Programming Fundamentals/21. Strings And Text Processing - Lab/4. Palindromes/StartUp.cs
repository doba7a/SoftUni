namespace Palindromes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Palindromes
    {
        public static void Main()
        {
            string[] inputText = Console.ReadLine().Split(new[] { ',', ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            SortedSet<string> palindromesSet = new SortedSet<string>();

            foreach (string word in inputText)
            {
                if (word.SequenceEqual(word.Reverse()))
                {
                    palindromesSet.Add(word);
                }
            }

            Console.WriteLine(string.Join(", ", palindromesSet));
        }
    }
}