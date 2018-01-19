namespace WordInPlural
{
    using System;

    public class WordInPlural
    {
        public static void Main()
        {
            var inputWord = Console.ReadLine();
            var outputWord = String.Empty;

            if (inputWord.EndsWith("y"))
            {
                outputWord = inputWord.Remove(inputWord.Length - 1) + "ies";
            }
            else if (inputWord.EndsWith("o") || inputWord.EndsWith("ch") || inputWord.EndsWith("s") ||
                inputWord.EndsWith("sh") || inputWord.EndsWith("x") || inputWord.EndsWith("z"))
            {
                outputWord = inputWord + "es";
            }
            else
            {
                outputWord = inputWord + 's';
            }

            Console.WriteLine(outputWord);
        }
    }
}