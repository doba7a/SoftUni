namespace RandomizeWords
{
    using System;

    public class RandomizeWords
    {
        public static void Main()
        {
            string[] arrayOfWords = Console.ReadLine().Split(' ');

            Random rnd = new Random();

            for (int i = 0; i < arrayOfWords.Length - 1; i++)
            {
                string currentWord = arrayOfWords[i];

                int randomIndex = rnd.Next(0, arrayOfWords.Length);
                string tempWord = arrayOfWords[randomIndex];

                arrayOfWords[i] = tempWord;
                arrayOfWords[randomIndex] = currentWord;
            }

            foreach (string word in arrayOfWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}