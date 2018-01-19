namespace ManipulateArray
{
    using System;
    using System.Linq;

    public class ManipulateArray
    {
        public static void Main()
        {
            string[] arrayOfWords = Console.ReadLine().Split(' ').ToArray();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string currentCommand = Console.ReadLine();

                if (currentCommand == "Distinct")
                {
                    string[] temporaryArray = arrayOfWords.Distinct().ToArray();
                    arrayOfWords = temporaryArray;
                }
                else if (currentCommand == "Reverse")
                {
                    Array.Reverse(arrayOfWords);
                }
                else
                {
                    int indexToChange = int.Parse(currentCommand.Split(' ')[1]);
                    string newWord = currentCommand.Split(' ')[2];

                    arrayOfWords[indexToChange] = newWord;
                }
            }

            Console.WriteLine(string.Join(", ", arrayOfWords));
        }
    }
}