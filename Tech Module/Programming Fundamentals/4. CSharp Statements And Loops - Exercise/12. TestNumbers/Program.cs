namespace TestNumbers
{
    using System;

    public class TestNumbers
    {
        public static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var boundary = int.Parse(Console.ReadLine());

            var sum = 0;
            var combinationsCount = 0;

            for (int i = firstNumber; i > 0; i--)
            {
                for (int j = 1; j <= secondNumber; j++)
                {
                    sum += 3 * (i * j);
                    combinationsCount++;

                    if (sum >= boundary)
                    {
                        Console.WriteLine($"{combinationsCount} combinations\r\nSum: {sum} >= {boundary}");
                        Environment.Exit(1);
                    }
                }
            }

            Console.WriteLine($"{combinationsCount} combinations\r\nSum: {sum}");
        }
    }
}