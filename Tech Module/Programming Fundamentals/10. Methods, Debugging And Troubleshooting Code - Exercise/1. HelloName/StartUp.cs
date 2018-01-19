namespace HelloName
{
    using System;

    public class HelloName
    {
        public static void Main()
        {
            string name = Console.ReadLine();

            PrintGreeting(name);
        }

        public static void PrintGreeting(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}