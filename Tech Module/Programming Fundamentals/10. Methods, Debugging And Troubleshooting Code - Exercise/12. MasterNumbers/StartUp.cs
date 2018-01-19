using System;

namespace MasterNumbers
{
    public class MasterNumbers
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (isPalindrome(i) && sumOfDigits(i) && containsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool isPalindrome(int n)
        {
            int currentNumber = n;
            int reversedCurrentNumber = 0;

            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;
                reversedCurrentNumber = reversedCurrentNumber * 10 + lastDigit;
                currentNumber = currentNumber / 10;
            }

            if (n == reversedCurrentNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool sumOfDigits(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool containsEvenDigit(int n)
        {
            while (n > 0)
            {
                int lastDigit = n % 10;

                if (lastDigit % 2 == 0)
                {
                    return true;
                }

                n = n / 10;
            }

            return false;
        }
    }
}