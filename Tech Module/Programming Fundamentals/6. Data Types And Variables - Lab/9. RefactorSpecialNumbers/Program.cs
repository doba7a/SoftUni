namespace SpecialNumbers
{
    using System;

    public class SpecialNumbers
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                var digitSum = 0;
                var number = i;
                while (number > 0)
                {
                    var lastDigit = number % 10;
                    number = number / 10;
                    digitSum = digitSum + lastDigit;
                }

                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}