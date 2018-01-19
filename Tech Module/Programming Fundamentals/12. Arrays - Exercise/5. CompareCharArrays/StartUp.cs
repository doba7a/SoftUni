namespace CompareCharArrays
{
    using System;
    using System.Linq;

    public class CompareCharArrays
    {
        public static void Main()
        {
            char[] firstWord = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] secondWord = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            int minLength = Math.Min(firstWord.Length, secondWord.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (firstWord[i] > secondWord[i])
                {
                    Console.WriteLine(secondWord);
                    Console.WriteLine(firstWord);
                    Environment.Exit(1);
                }
                else if (firstWord[i] < secondWord[i])
                {
                    Console.WriteLine(firstWord);
                    Console.WriteLine(secondWord);
                    Environment.Exit(1);
                }
            }

            if (firstWord.Length >= secondWord.Length)
            {
                Console.WriteLine(secondWord);
                Console.WriteLine(firstWord);
            }
            else if(firstWord.Length < secondWord.Length)
            {
                Console.WriteLine(firstWord);
                Console.WriteLine(secondWord);
            }
        }
    }
}