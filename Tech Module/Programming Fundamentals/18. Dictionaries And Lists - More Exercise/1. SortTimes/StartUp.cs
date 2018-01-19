namespace SortTimes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SortTimes
    {
        public static void Main()
        {
            List<string> hoursList = Console.ReadLine()
                .Split(' ')
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", hoursList));
        }
    }
}