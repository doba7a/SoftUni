namespace MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection namesCollection = Regex.Matches(Console.ReadLine(), pattern);

            foreach (Match name in namesCollection)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine();
        }
    }
}