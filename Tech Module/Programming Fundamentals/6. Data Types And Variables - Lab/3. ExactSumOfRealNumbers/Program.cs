namespace ExactSumOfRealNumbers
{
    using System;

    public class ExactSumOfRealNumbers
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                var currentNumber = decimal.Parse(Console.ReadLine());
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }
    }
}