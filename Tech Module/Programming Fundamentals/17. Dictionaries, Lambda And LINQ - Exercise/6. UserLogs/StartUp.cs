namespace UserLogs
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class UserLogs
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> userLogsDictionary
                = new SortedDictionary<string, Dictionary<string, int>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "end")
            {
                List<string> currentInputData = currentInput.Split(' ').ToList();

                string currentUser = currentInputData[2].Substring(5);

                if (!userLogsDictionary.ContainsKey(currentUser))
                {
                    userLogsDictionary[currentUser] = new Dictionary<string, int>();
                }

                string currentUserIP = currentInputData[0].Substring(3);

                if (!userLogsDictionary[currentUser].ContainsKey(currentUserIP))
                {
                    userLogsDictionary[currentUser][currentUserIP] = 0;
                }

                userLogsDictionary[currentUser][currentUserIP]++;

                currentInput = Console.ReadLine();
            }

            foreach (var user in userLogsDictionary)
            {
                StringBuilder output = new StringBuilder();
                string currentUserName = user.Key;

                output.Append($"{currentUserName}:{Environment.NewLine}");

                Dictionary<string, int> currentUserIPData = user.Value;

                foreach (var IPData in currentUserIPData)
                {
                    output.Append($"{IPData.Key} => {IPData.Value}, ");
                }

                output.Remove(output.Length - 2, 2);
                output.Append(".");

                Console.WriteLine(output);
            }
        }
    }
}