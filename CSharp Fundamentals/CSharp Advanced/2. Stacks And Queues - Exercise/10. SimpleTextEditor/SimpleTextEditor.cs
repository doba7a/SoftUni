namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            Stack<string> formerQueues = new Stack<string>();
            StringBuilder workingText = new StringBuilder();

            int inputsGiven = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsGiven; i++)
            {
                string[] currentCommandData = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = currentCommandData[0];

                switch (currentCommand)
                {
                    case "1":
                        string textToAdd = currentCommandData[1];

                        formerQueues.Push(workingText.ToString());

                        workingText.Append(textToAdd);

                        break;
                    case "2":
                        int elementsToRemove = Math.Min(int.Parse(currentCommandData[1]), workingText.Length);

                        formerQueues.Push(workingText.ToString());

                        workingText.Remove(workingText.Length - elementsToRemove, elementsToRemove);

                        break;
                    case "3":
                        int index = int.Parse(currentCommandData[1]);

                        Console.WriteLine(workingText[index - 1]);

                        break;
                    case "4":
                        workingText = new StringBuilder(formerQueues.Pop());
                        break;
                }
            }
        }
    }
}
