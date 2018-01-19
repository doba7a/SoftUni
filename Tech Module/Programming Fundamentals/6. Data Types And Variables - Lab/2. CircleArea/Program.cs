namespace CircleArea
{
    using System;

    public class CircleArea
    {
        public static void Main()
        {
            var r = double.Parse(Console.ReadLine());

            Console.WriteLine($"{(Math.PI * r * r):F12}");
        }
    }
}