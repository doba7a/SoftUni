namespace MaximumElement
{
    using System;
    using System.Collections.Generic;

    public class MaximumElement
    {
        public static void Main()
        {
            int inputsGiven = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxElements = new Stack<int>();
            int maxElement = int.MinValue;

            for (int i = 0; i < inputsGiven; i++)
            {
                string[] currentInput = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = currentInput[0];

                switch (command)
                {
                    case "1":
                        int elementToPush = int.Parse(currentInput[1]);

                        if (maxElement < elementToPush)
                        {
                            maxElement = elementToPush;
                            maxElements.Push(elementToPush);
                        }

                        stack.Push(elementToPush);

                        break;
                    case "2":
                        if (stack.Peek() == maxElements.Peek() && maxElements.Count > 0)
                        {
                            maxElements.Pop();

                            if (maxElements.Count > 0)
                            {
                                maxElement = maxElements.Peek();
                            }
                            else
                            {
                                maxElement = int.MinValue;
                            }
                        }

                        stack.Pop();

                        break;
                    case "3":
                        Console.WriteLine(maxElements.Peek());

                        break;
                }
            }
        }
    }
}
