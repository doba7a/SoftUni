namespace ExchangeVariableValues
{
    using System;

    public class ExchangeVariableValues
    {
        public static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("Before:");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);

            int newA = b;
            int newB = a;
            Console.WriteLine("After:");
            Console.WriteLine("a = {0}", newA);
            Console.WriteLine("b = {0}", newB);
        }
    }
}