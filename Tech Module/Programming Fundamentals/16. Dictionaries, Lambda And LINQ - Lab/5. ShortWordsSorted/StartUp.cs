namespace shortWordsSorted
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class shortWordsSorted
    {
        public static void Main()
        {
            List<string> resultList = Console.ReadLine()
                .ToLower()
                .Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", resultList));
        }
    }
}
