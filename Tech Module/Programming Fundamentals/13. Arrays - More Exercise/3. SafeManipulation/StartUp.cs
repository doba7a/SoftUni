namespace SafeManipulation
{
    using System;
    using System.Linq;

    public class SafeManipulation
    {
        public static void Main()
        {
            string[] arrayOfWords = Console.ReadLine().Split(' ').ToArray();

            string currentCommand = Console.ReadLine();

            while (currentCommand != "END")
            {
                if (currentCommand == "Distinct")
                {
                    string[] temporaryArray = arrayOfWords.Distinct().ToArray();

                    arrayOfWords = temporaryArray;
                }
                else if (currentCommand == "Reverse")
                {
                    Array.Reverse(arrayOfWords);
                }
                else if (currentCommand.Split(' ')[0] == "Replace")
                {
                    int indexToChange = int.Parse(currentCommand.Split(' ')[1]);

                    if (indexToChange < 0 || indexToChange > arrayOfWords.Length - 1)
                    {
                        Console.WriteLine("Invalid input!");
                        currentCommand = Console.ReadLine();
                        continue;
                    }

                    string newWord = currentCommand.Split(' ')[2];

                    arrayOfWords[indexToChange] = newWord;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    currentCommand = Console.ReadLine();
                    continue;
                }

                currentCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", arrayOfWords));
        }
    }
}