namespace MelrahShake
{
    using System;

    public class MelrahShake
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();
            string pattern = Console.ReadLine();

            while (true)
            {
                int firstIndexOfPattern = input.IndexOf(pattern);
                int lastIndexOfPattern = input.LastIndexOf(pattern);

                if (firstIndexOfPattern > -1 && lastIndexOfPattern > -1 && pattern.Length > 0)
                {
                    firstIndexOfPattern = input.IndexOf(pattern);
                    input = input.Remove(firstIndexOfPattern, pattern.Length);

                    lastIndexOfPattern = input.LastIndexOf(pattern);
                    input = input.Remove(lastIndexOfPattern, pattern.Length);

                    Console.WriteLine("Shaked it.");

                    if (pattern.Length > 0)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }

                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    Environment.Exit(1);
                }
            }
        }
    }
}