namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            Dictionary<string, int> wordsCountDict = new Dictionary<string, int>();

            Console.Write("Enter words file directory and name with extension:");
            string directoryAndName = Console.ReadLine();

            AddWords(directoryAndName, wordsCountDict);

            Console.Write("Enter text file directory and name with extension:");
            directoryAndName = Console.ReadLine();

            CountWords(directoryAndName, wordsCountDict);

            Result(wordsCountDict);
        }

        public static void AddWords(string directoryAndName, Dictionary<string, int> wordsCountDict)
        {
            try
            {
                using (StreamReader sr = new StreamReader(directoryAndName))
                {
                    string word = sr.ReadLine().ToLower();

                    while (word != null)
                    {
                        wordsCountDict[word] = 0;

                        word = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid path or file name. Press any key to exit.");
                Environment.Exit(0);
            }
        }

        public static void CountWords(string directoryAndName, Dictionary<string, int> wordsCountDict)
        {
            try
            {
                using (StreamReader sr = new StreamReader(directoryAndName))
                {
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] words = line
                            .Split(new[] { ' ', ',', '.', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(w => w.ToLower())
                            .ToArray();

                        foreach (string word in words)
                        {
                            if (wordsCountDict.ContainsKey(word))
                            {
                                wordsCountDict[word]++;
                            }
                        }

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid path or file name. Press any key to exit.");
                Environment.Exit(0);
            }
        }

        public static void Result(Dictionary<string, int> wordsCountDict)
        {
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                foreach (KeyValuePair<string, int> kvp in wordsCountDict.OrderByDescending(x => x.Value))
                {
                    sw.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            Console.WriteLine("Result added to result.txt in project folder. Press any key to exit.");
        }
    }
}
