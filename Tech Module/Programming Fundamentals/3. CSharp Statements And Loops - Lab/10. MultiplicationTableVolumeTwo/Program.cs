namespace MultiplicationTableVolTwo
{
    using System;

    public class MultiplicationTableVolTwo
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var startingMultiplier = int.Parse(Console.ReadLine());

            if (startingMultiplier > 10)
            {
                Console.WriteLine($"{n} X {startingMultiplier} = {n * startingMultiplier}");
                Environment.Exit(1);
            }

            for (int i = startingMultiplier; i <= 10; i++)
            {
                Console.WriteLine($"{n} X {i} = {n * i}");
            }
        }
    }
}