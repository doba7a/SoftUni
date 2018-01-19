namespace PhonebookUpgrade
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PhonebookUpgrade
    {
        public static void Main()
        {
            SortedDictionary<string, string> phonebookData = new SortedDictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> currentInputData = input.Split(' ').ToList();

                string currentCommand = currentInputData[0];

                if (currentCommand == "A")
                {
                    string currentPersonName = currentInputData[1];
                    string currentPersonNumber = currentInputData[2];
                    phonebookData[currentPersonName] = currentPersonNumber;
                }
                else if (currentCommand == "S")
                {
                    string currentPersonName = currentInputData[1];

                    if (phonebookData.ContainsKey(currentPersonName))
                    {
                        Console.WriteLine($"{currentPersonName} -> {phonebookData[currentPersonName]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {currentPersonName} does not exist.");
                    }
                }
                else if (currentCommand == "ListAll")
                {
                    foreach (var person in phonebookData)
                    {
                        Console.WriteLine($"{person.Key} -> {person.Value}");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}