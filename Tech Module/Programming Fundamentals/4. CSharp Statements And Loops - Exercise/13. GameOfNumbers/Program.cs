namespace GameOfNumbers
{
    using System;

    public class GameOfNumbers
    {
        public static void Main()
        {
            var startingInteger = int.Parse(Console.ReadLine());
            var finalInteger = int.Parse(Console.ReadLine());
            var magicInteger = int.Parse(Console.ReadLine());

            var firstNumber = 0;
            var secondNumber = 0;
            var combinations = 0;
            var foundMagicInteger = false;

            for (int i = startingInteger; i <= finalInteger; i++)
            {
                for (int j = startingInteger; j <= finalInteger; j++)
                {
                    combinations++;
                    if (i + j == magicInteger)
                    {
                        firstNumber = i;
                        secondNumber = j;
                        foundMagicInteger = true;
                    }
                }
            }

            if (foundMagicInteger)
            {
                Console.WriteLine($"Number found! {firstNumber} + {secondNumber} = {magicInteger}");
            }
            else
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicInteger}");
            }
        }
    }
}