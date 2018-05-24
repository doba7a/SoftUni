using System;

public class StartUp
{
    public static void Main()
    {
        LinkedList<int> linkedList = new LinkedList<int>();

        ExecuteCommands(linkedList);

        PrintResult(linkedList);
    }

    private static void PrintResult(LinkedList<int> linkedList)
    {
        Console.WriteLine(linkedList.Count);

        Console.WriteLine(string.Join(" ", linkedList));
    }

    private static void ExecuteCommands(LinkedList<int> linkedList)
    {
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commandData = Console.ReadLine().Split();

            string command = commandData[0];
            int number = int.Parse(commandData[1]);

            switch (command)
            {
                case "Add":
                    linkedList.Add(number);
                    break;
                case "Remove":
                    linkedList.Remove(number);
                    break;
                default:
                    break;
            }
        }
    }
}
