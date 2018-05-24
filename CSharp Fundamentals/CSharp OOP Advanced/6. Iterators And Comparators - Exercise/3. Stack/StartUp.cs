using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Stack<int> customStack = new Stack<int>();

        string[] input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        string command = input[0];

        while (command != "END")
        {
            if (command == "Pop")
            {
                if (customStack.ExistingElementToPop)
                {
                    customStack.Pop();
                }
                else
                {
                    Console.WriteLine("No elements");
                }
            }
            else
            {
                customStack.Push(input.Skip(1).Select(int.Parse).ToArray());
            }

            input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            command = input[0];
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (int element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}

