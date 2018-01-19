namespace UnicodeCharacters
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class UnicodeCharacters
    {
        public static void Main()
        {
            char[] inputStringAsCharArray = Console.ReadLine().ToCharArray();

            List<string> resultSequence = inputStringAsCharArray.Select(x => $"\\u{Convert.ToUInt16(x):x4}").ToList();

            Console.WriteLine(string.Join("", resultSequence));
        }
    }
}