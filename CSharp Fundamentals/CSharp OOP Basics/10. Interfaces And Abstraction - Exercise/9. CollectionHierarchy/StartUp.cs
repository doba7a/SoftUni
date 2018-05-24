using System;
using System.Text;

public class StartUp
{
    private static StringBuilder sb = new StringBuilder();
    private static StringCollection myCollection = new StringCollection();

    public static void Main(string[] args)
    {   
        string[] inputItems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int removeOperations = int.Parse(Console.ReadLine());

        AddItems(inputItems);
        PrintZeros();
        PrintZeros();
        RemoveFromCollections(removeOperations);
        RemoveFromMyList(removeOperations);

        Console.WriteLine(sb.ToString().TrimEnd());
    }

    private static void RemoveFromMyList(int removeOperations)
    {
        for (int i = 0; i < removeOperations; i++)
        {
            sb.Append(myCollection.RemoveFirst() + " ");
        }
        sb.AppendLine();
    }

    private static void RemoveFromCollections(int removeOperations)
    {
        for (int i = 0; i < removeOperations; i++)
        {
            sb.Append(myCollection.RemoveLast() + " ");
        }
        sb.AppendLine();
    }

    private static void PrintZeros()
    {
        for (int i = 0; i < myCollection.Count; i++)
        {
            sb.Append("0 ");
        }
        sb.AppendLine();

    }

    private static void AddItems(string[] inputItems)
    {
        foreach (var item in inputItems)
        {
            sb.Append(myCollection.Add(item) + " ");
        }
        sb.AppendLine();
    }
}

