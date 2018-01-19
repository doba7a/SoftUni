namespace LogsAggregator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LogsAggregator
    {
        public static void Main()
        {
            SortedDictionary<string, HashSet<string>> usersIP =
                new SortedDictionary<string, HashSet<string>>();

            Dictionary<string, int> usersDuration =
                new Dictionary<string, int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                List<string> currentInputData = Console.ReadLine().Split(' ').ToList();

                string currentUser = currentInputData[1];

                if (!usersIP.ContainsKey(currentUser) && !usersDuration.ContainsKey(currentUser))
                {
                    usersIP[currentUser] = new HashSet<string>();
                    usersDuration[currentUser] = 0;
                }

                string currentUserIP = currentInputData[0];

                usersIP[currentUser].Add(currentUserIP);

                int currentUserLogDuration = int.Parse(currentInputData[2]);

                usersDuration[currentUser] += currentUserLogDuration;
            }

            foreach (var user in usersIP)
            {
                string currentUserName = user.Key;
                List<string> currentUserIPs = user.Value.OrderBy(x => x).ToList();
                int currentUserLogDuration = usersDuration[currentUserName];

                Console.WriteLine($"{currentUserName}: {currentUserLogDuration} [{string.Join(", ", currentUserIPs)}]");
            }
        }
    }
}