namespace FiveDifferentNumbers
{
    using System;

    public class FiveDifferentNumbers
    {
        public static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber - firstNumber < 4)
            {
                Console.WriteLine("No");
                Environment.Exit(1);
            }

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = i + 1; j <= secondNumber; j++)
                {
                    for (int k = j + 1; k <= secondNumber; k++)
                    {
                        for (int l = k + 1; l <= secondNumber; l++)
                        {
                            for (int h = l + 1; h <= secondNumber; h++)
                            {
                                Console.WriteLine($"{i} {j} {k} {l} {h}");
                            }
                        }
                    }
                }
            }
        }
    }
}