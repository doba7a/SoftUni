namespace OddOccurrences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class OddOccurrences
    {
        public static void Main()
        {
            List<string> listOfWords = Console.ReadLine().ToLower().Split(' ').ToList();

            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();

            for (int i = 0; i < listOfWords.Count; i++)
            {
                if (!wordDictionary.ContainsKey(listOfWords[i]))
                {
                    wordDictionary[listOfWords[i]] = 0;
                }
                wordDictionary[listOfWords[i]]++;
            }

            List<string> resultList = new List<string>();

            foreach (var word in wordDictionary.Where(x => x.Value % 2 != 0))
            {
                resultList.Add(word.Key);
            }

            Console.WriteLine(string.Join(", ", resultList));
        }
    }
}