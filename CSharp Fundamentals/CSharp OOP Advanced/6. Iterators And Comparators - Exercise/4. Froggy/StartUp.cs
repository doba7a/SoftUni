using System;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        int[] stoneNumbers = Console.ReadLine()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Lake lake = new Lake(stoneNumbers);

        StringBuilder sb = new StringBuilder();

        foreach (int stoneNumber in lake)
        {
            sb.Append($"{stoneNumber}, ");
        }

        sb.Remove(sb.Length - 2, 2).AppendLine();

        Console.WriteLine(sb.ToString().TrimEnd());
    }
}

