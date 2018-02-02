namespace FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class FilterByAge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> peopleDict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] currentData = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string curretName = currentData[0];
                int currentAge = int.Parse(currentData[1]);

                peopleDict[curretName] = currentAge;
            }

            string youngerOrOlder = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<string, int, int, bool> condition = Condition;
            Action<string, string, int> printResult = PrintResult;

            foreach (var kvp in peopleDict)
            {
                string currentName = kvp.Key;
                int currentAge = kvp.Value;

                if (condition(youngerOrOlder, currentAge, filterAge))
                {
                    printResult(format, currentName, currentAge);
                }
            }
        }

        private static bool Condition(string condition, int currentAge, int filterAge)
        {
            switch (condition)
            {
                case "younger":
                    return currentAge < filterAge;
                case "older":
                    return currentAge >= filterAge;
                default:
                    return false;
            }
        }

        private static void PrintResult(string format, string name, int age)
        {
            switch (format)
            {
                case "name":
                    Console.WriteLine($"{name}");
                    break;
                case "age":
                    Console.WriteLine($"{age}");
                    break;
                case "name age":
                    Console.WriteLine($"{name} - {age}");
                    break;
            }
        }
    }
}
