using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Box<int>> list = new List<Box<int>>();

        for (int i = 0; i < numberOfInputs; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> stringBox = new Box<int>(input);

            list.Add(stringBox);
        }

        Swap(list);

        foreach (var box in list)
        {
            Console.WriteLine(box);
        }
    }

    private static void Swap<T>(List<Box<T>> list)
        where T : struct
    {
        int[] swapData = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int firstPosition = swapData[0];
        int secondPosition = swapData[1];

        Box<T> tempElement = list[firstPosition];
        list[firstPosition] = list[secondPosition];
        list[secondPosition] = tempElement;
    }
}
