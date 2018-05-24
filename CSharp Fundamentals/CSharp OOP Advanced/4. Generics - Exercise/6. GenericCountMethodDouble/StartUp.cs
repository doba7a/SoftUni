using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Box<double>> list = new List<Box<double>>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            double input = double.Parse(Console.ReadLine());

            Box<double> stringBox = new Box<double>(input);

            list.Add(stringBox);
        }

        double compareTo = double.Parse(Console.ReadLine());

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

