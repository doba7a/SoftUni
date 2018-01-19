namespace MagicExhangeableWords
{
    using System;
    using System.Linq;

    public class MagicExhangeableWords
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ');

            bool areExchangeable = CheckIfWordsAreExchangeable(inputData[0], inputData[1]);

            Console.WriteLine(areExchangeable.ToString().ToLower());
        }

        public static bool CheckIfWordsAreExchangeable(string firstString, string secondString)
        {
            if (firstString.ToCharArray().Distinct().Count() == secondString.ToCharArray().Distinct().Count())
            {
                return true;
            }

            return false;
        }
    }
}