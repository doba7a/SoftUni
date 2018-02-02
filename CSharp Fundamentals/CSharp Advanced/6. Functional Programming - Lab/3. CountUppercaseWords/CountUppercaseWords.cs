namespace CountUppercaseWords
{
    using System;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> uppercase = w => char.IsUpper(w[0]);

            foreach (string word in words)
            {
                if (uppercase(word))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
