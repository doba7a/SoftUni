using System;

public class CommandInterpreter
{
    private CustomList<string> customList;

    public CommandInterpreter(CustomList<string> customList)
    {
        this.customList = customList;
    }

    public void ReadCommands()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] inputData = input.Split(' ');

            switch (inputData[0])
            {
                case "Add":
                    customList.Add(inputData[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(inputData[1]));
                    break;
                case "Contains":
                    bool containsResult = customList.Contains(inputData[1]);
                    Console.WriteLine(containsResult);
                    break;
                case "Swap":
                    customList.Swap(int.Parse(inputData[1]), int.Parse(inputData[2]));
                    break;
                case "Greater":
                    string greaterResult = customList.CountGreaterThan(inputData[1]).ToString();
                    Console.WriteLine(greaterResult);
                    break;
                case "Max":
                    string maxResult = customList.Max();
                    Console.WriteLine(maxResult);
                    break;
                case "Min":
                    string minResult = customList.Min();
                    Console.WriteLine(minResult);
                    break;
                case "Print":
                    string printResult = customList.Print();
                    Console.WriteLine(printResult);
                    break;
                case "Sort":
                    customList.Sort();
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

