namespace QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        public static void Main()
        {
            string fieldAndValuePattern = @"([^&=?]*)=([^&=]*)";
            string regex = @"((%20|\+)+)";

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                MatchCollection fieldsAndValuesMatches = Regex.Matches(inputLine, fieldAndValuePattern);

                Dictionary<string, List<string>> currentResultsDictionary = new Dictionary<string, List<string>>();

                for (int i = 0; i < fieldsAndValuesMatches.Count; i++)
                {
                    string currentField = fieldsAndValuesMatches[i].Groups[1].Value;
                    currentField = Regex.Replace(currentField, regex, word => " ").Trim();

                    string currentValue = fieldsAndValuesMatches[i].Groups[2].Value;
                    currentValue = Regex.Replace(currentValue, regex, word => " ").Trim();

                    if (!currentResultsDictionary.ContainsKey(currentField))
                    {
                        List<string> values = new List<string>();

                        values.Add(currentValue);
                        currentResultsDictionary.Add(currentField, values);
                    }
                    else if (currentResultsDictionary.ContainsKey(currentField))
                    {
                        currentResultsDictionary[currentField].Add(currentValue);
                    }
                }

                foreach (var pair in currentResultsDictionary)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                Console.WriteLine();

                inputLine = Console.ReadLine();
            }
        }
    }
}