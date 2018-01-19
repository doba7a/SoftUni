namespace multiplyEvenByOdds
{
    using System;

    public class multiplyEvenByOdds
    {
        public static void Main()
        {
            int n = Math.Abs(int.Parse(Console.ReadLine()));

            int result = getResult(n);

            Console.WriteLine(result);
        }

        public static int getResult(int n)
        {
            int oddsSum = 0;
            int evensSum = 0;

            while (n > 0)
            {
                int lastDigit = n % 10;

                if (lastDigit % 2 != 0)
                {
                    oddsSum += lastDigit;
                }
                else
                {
                    evensSum += lastDigit;
                }

                n = n / 10;
            }

            return oddsSum * evensSum;
        }
    }
}