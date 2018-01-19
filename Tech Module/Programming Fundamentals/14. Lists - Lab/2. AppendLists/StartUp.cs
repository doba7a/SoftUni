namespace AppendLists
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AppendLists
    {
        public static void Main()
        {
            List<string> listOfLists = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();

            List<int> resultList = new List<int>();

            foreach (string token in listOfLists)
            {
                List<int> listToAdd = token
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                resultList.AddRange(listToAdd);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}