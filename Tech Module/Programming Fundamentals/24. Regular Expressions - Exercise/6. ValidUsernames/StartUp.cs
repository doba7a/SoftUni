namespace ValidUsernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            string[] arrayOfUsernames = Console.ReadLine()
                .Split(new[] { ' ', '\\', '/', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            string validUsernamesPattern = @"^[A-Za-z][A-Za-z0-9_]{2,24}$";

            List<string> validUsernames = new List<string>();

            foreach (string username in arrayOfUsernames)
            {
                if (Regex.IsMatch(username, validUsernamesPattern))
                {
                    validUsernames.Add(username);
                }
            }

            int sum = 0;
            string[] pairOfUsernamesWithBiggestLength = new string[2];

            for (int i = 1; i < validUsernames.Count; i++)
            {
                int tempSum = validUsernames[i - 1].Length + validUsernames[i].Length;

                if (tempSum > sum)
                {
                    sum = tempSum;
                    pairOfUsernamesWithBiggestLength[0] = validUsernames[i - 1];
                    pairOfUsernamesWithBiggestLength[1] = validUsernames[i];
                }
            }

            Console.WriteLine(string.Join($"{ Environment.NewLine}", pairOfUsernamesWithBiggestLength));
        }
    }
}