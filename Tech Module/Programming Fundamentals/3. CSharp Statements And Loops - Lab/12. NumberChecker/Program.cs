namespace NumberChecker
{
    using System;

    public class NumberChecker
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            try
            {
                int.Parse(input);
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}