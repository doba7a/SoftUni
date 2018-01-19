namespace MultiplyBigNumbers
{
    using System;
    using System.Text;

    public class MultiplyBigNumbers
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            string multiplier = Console.ReadLine().TrimStart(new char[] { '0' });

            string resultNumber = MultiplicationOfNumbers(firstNumber, multiplier);

            Console.WriteLine(resultNumber);
        }

        public static string MultiplicationOfNumbers(string firstNumberGiven, string multiplierGiven)
        {
            if (multiplierGiven == string.Empty)
            {
                return "0";
            }

            StringBuilder resultNumber = new StringBuilder();

            string firstNumber = firstNumberGiven;
            int multiplier = int.Parse(multiplierGiven);

            int addToNextCalculation = 0;

            while (firstNumber.Length > 0)
            {
                int lastDigitFromFirstNumber = int.Parse(firstNumber.Substring(firstNumber.Length - 1, 1));

                firstNumber = firstNumber.Remove(firstNumber.Length - 1);

                int tempNumber = lastDigitFromFirstNumber * multiplier;

                tempNumber += addToNextCalculation;

                if (tempNumber < 10)
                {
                    resultNumber.Insert(0, tempNumber);
                    addToNextCalculation = 0;
                }
                else
                {
                    resultNumber.Insert(0, tempNumber % 10);
                    addToNextCalculation = (int)(tempNumber.ToString()[0]) - 48;
                }
            }

            if (addToNextCalculation > 0)
            {
                resultNumber.Insert(0, addToNextCalculation);
            }

            return resultNumber.ToString();
        }
    }
}