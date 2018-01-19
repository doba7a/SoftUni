namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            Dictionary<string, string> phonebookData = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> currentInputData = input.Split(' ').ToList();

                string currentCommand = currentInputData[0];
                string currentPersonName = currentInputData[1];

                if (currentCommand == "A")
                {
                    string currentPersonNumber = currentInputData[2];
                    phonebookData[currentPersonName] = currentPersonNumber;
                }
                else if (currentCommand == "S")
                {
                    if (phonebookData.ContainsKey(currentPersonName))
                    {
                        Console.WriteLine($"{currentPersonName} -> {phonebookData[currentPersonName]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {currentPersonName} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}