namespace FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            Dictionary<string, string> emailsDictionary = new Dictionary<string, string>();

            string currentName = Console.ReadLine();

            while (currentName != "stop")
            {
                string currentEmail = Console.ReadLine();

                if (currentEmail.ToLower().EndsWith("us") || currentEmail.ToLower().EndsWith("uk"))
                {
                    currentName = Console.ReadLine();
                    continue;
                }

                emailsDictionary[currentName] = currentEmail;

                currentName = Console.ReadLine();
            }

            foreach (var email in emailsDictionary)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
        }
    }
}