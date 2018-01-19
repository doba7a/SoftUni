namespace Elevator
{
    using System;

    public class Elevator
    {
        public static void Main()
        {
            var people = double.Parse(Console.ReadLine());
            var capacity = double.Parse(Console.ReadLine());

            Console.WriteLine($"{Math.Ceiling(people / capacity)}");
        }
    }
}