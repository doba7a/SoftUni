namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            Stack<long> fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            long n = long.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)
            {
                long firstElement = fibonacciStack.Pop();
                long secondElement = fibonacciStack.Pop();

                long newElement = firstElement + secondElement;

                fibonacciStack.Push(firstElement);
                fibonacciStack.Push(newElement);
            }

            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}
