namespace NumberChecker
{
    using System;

    public class NumberChecker
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            long integer = 0;

            if (long.TryParse(input, out integer))
            {
                Console.WriteLine("integer");
            }
            else
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}