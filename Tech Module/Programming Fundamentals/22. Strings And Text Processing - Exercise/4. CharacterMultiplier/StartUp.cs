namespace CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] inputData = Console.ReadLine().Split(' ');

            long charactersSum = CalculateCharactersSum(inputData[0], inputData[1]);

            Console.WriteLine(charactersSum);
        }

        public static long CalculateCharactersSum(string firstString, string secondString)
        {
            long charactersSum = 0;

            int minLength = Math.Min(firstString.Length, secondString.Length);
            int maxLength = Math.Max(firstString.Length, secondString.Length);

            for (int i = 0; i < minLength; i++)
            {
                charactersSum += firstString[i] * secondString[i];
            }

            if (minLength == maxLength)
            {
                return charactersSum;
            }

            if (firstString.Length > secondString.Length)
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    charactersSum += firstString[i];
                }
            }
            else
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    charactersSum += secondString[i];
                }
            }

            return charactersSum;
        }
    }
}