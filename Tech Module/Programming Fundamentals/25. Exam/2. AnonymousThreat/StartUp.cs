namespace AnonymousThreat
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class AnonymousThreat
    {
        public static void Main()
        {
            List<string> listOfStrings = Console.ReadLine().Split(' ').ToList();

            string currentCommand = Console.ReadLine();

            while (currentCommand != "3:1")
            {
                string[] currentCommandData = currentCommand.Split(' ');

                string currentCommandName = currentCommandData[0];

                if (currentCommandName == "merge")
                {
                    MergePartOfList(listOfStrings, currentCommandData);
                }
                else if (currentCommandName == "divide")
                {
                    DividePartOfList(listOfStrings, currentCommandData);
                }

                currentCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", listOfStrings));
        }

        public static void DividePartOfList(List<string> listOfStrings, string[] currentCommandData)
        {
            int indexGiven = int.Parse(currentCommandData[1]);
            string stringToDIvide = listOfStrings[indexGiven];

            int partitions = int.Parse(currentCommandData[2]);

            int chunkSize = stringToDIvide.Length / partitions;
            int start = 0;

            List<string> dividedString = new List<string>();

            if (stringToDIvide.Length % partitions == 0)
            {
                for (int i = 0; i < partitions; i++)
                {
                    dividedString.Add(stringToDIvide.Substring(start, chunkSize));
                    start += chunkSize;
                }
            }
            else
            {
                for (int i = 0; i < partitions; i++)
                {
                    if (partitions - 1 > i)
                    {
                        dividedString.Add(stringToDIvide.Substring(start, chunkSize));
                        start += chunkSize;
                    }
                    else
                    {
                        dividedString.Add(stringToDIvide.Substring(start));
                    }
                }
            }

            listOfStrings.RemoveAt(indexGiven);
            listOfStrings.InsertRange(indexGiven, dividedString);
        }

        public static void MergePartOfList(List<string> listOfStrings, string[] currentCommandData)
        {
            int startIndex = Math.Max(int.Parse(currentCommandData[1]), 0);
            int endIndex = Math.Min(int.Parse(currentCommandData[2]), listOfStrings.Count - 1);

            StringBuilder mergedString = new StringBuilder();
            bool mergeSuccesfull = false;

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedString.Append(listOfStrings[i]);
                mergeSuccesfull = true;
            }

            if (mergeSuccesfull)
            {
                listOfStrings.RemoveRange(startIndex, endIndex - startIndex + 1);
                listOfStrings.Insert(startIndex, mergedString.ToString());
            }
        }
    }
}