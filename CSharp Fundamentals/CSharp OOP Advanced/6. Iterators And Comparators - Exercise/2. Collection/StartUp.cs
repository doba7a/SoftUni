using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        ListyIterator<string> listyIterator = CreateListyIterator();

        string result = ReadCommands(listyIterator);

        Console.WriteLine(result);
    }

    private static ListyIterator<string> CreateListyIterator()
    {
        IEnumerable<string> elements = Console.ReadLine().Split(' ').Skip(1).ToList();

        ListyIterator<string> listyIterator;

        if (elements.Any())
        {
            listyIterator = new ListyIterator<string>(elements);
        }
        else
        {
            listyIterator = new ListyIterator<string>();
        }

        return listyIterator;
    }

    private static string ReadCommands(ListyIterator<string> listyIterator)
    {
        StringBuilder sb = new StringBuilder();

        string input = Console.ReadLine();

        while (input != "END")
        {
            switch (input)
            {
                case "Move":
                    bool moveResult = listyIterator.Move();
                    sb.AppendLine(moveResult.ToString());
                    break;
                case "Print":
                    try
                    {
                        string printResult = listyIterator.Print();
                        sb.AppendLine(printResult);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        sb.AppendLine(ioe.Message);
                    }
                    break;
                case "HasNext":
                    bool hasNextResult = listyIterator.HasNext();
                    sb.AppendLine(hasNextResult.ToString());
                    break;
                case "PrintAll":
                    string printAllResult = listyIterator.PrintAll();
                    sb.AppendLine(printAllResult);
                    break;
            }

            input = Console.ReadLine();
        }

        return sb.ToString().TrimEnd();
    }
}


