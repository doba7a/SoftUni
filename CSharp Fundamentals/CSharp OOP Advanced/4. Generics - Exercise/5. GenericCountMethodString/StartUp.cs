using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Box<string>> list = new List<Box<string>>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            string input = Console.ReadLine();

            Box<string> stringBox = new Box<string>(input);

            list.Add(stringBox);
        }

        string compareTo = Console.ReadLine();

        Console.WriteLine(CountGreater(list, compareTo));
    }

    private static int CountGreater<T>(IEnumerable<Box<T>> collection, T element)
        where T : IComparable<T>
    {
        int counter = 0;

        foreach (var item in collection)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }
}

