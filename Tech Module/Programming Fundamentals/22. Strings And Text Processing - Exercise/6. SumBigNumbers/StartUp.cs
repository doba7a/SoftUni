namespace SumBigNumbers
{
    using System;
    using System.Text;

    public class SumBigNumbers
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            string secondNumber = Console.ReadLine().TrimStart(new char[] { '0' });

            string resultNumber = SumOfNumbers(firstNumber, secondNumber);

            Console.WriteLine(resultNumber);
        }

        public static string SumOfNumbers(string firstNumberGiven, string secondNumberGiven)
        {
            StringBuilder resultNumber = new StringBuilder();

            string firstNumber = firstNumberGiven;
            string secondNumber = secondNumberGiven;

            bool addToNextCalculation = false;

            while (firstNumber.Length > 0 && secondNumber.Length > 0)
            {
                int lastDigitFromFirstNumber = int.Parse(firstNumber.Substring(firstNumber.Length - 1, 1));
                int lastDigitFromSecondNumber = int.Parse(secondNumber.Substring(secondNumber.Length - 1, 1));

                firstNumber = firstNumber.Remove(firstNumber.Length - 1);
                secondNumber = secondNumber.Remove(secondNumber.Length - 1);

                int tempNumber = lastDigitFromFirstNumber + lastDigitFromSecondNumber;

                if (addToNextCalculation)
                {
                    tempNumber++;
                }

                if (tempNumber < 10)
                {
                    resultNumber.Insert(0, tempNumber);
                    addToNextCalculation = false;
                }
                else
                {
                    resultNumber.Insert(0, tempNumber % 10);
                    addToNextCalculation = true;
                }
            }

            if (firstNumber.Length == 0 && secondNumber.Length == 0)
            {
                return resultNumber.ToString();
            }

            if (firstNumber.Length > 0)
            {
                while (firstNumber.Length > 0)
                {
                    int tempNumber = int.Parse(firstNumber.Substring(firstNumber.Length - 1, 1));

                    firstNumber = firstNumber.Remove(firstNumber.Length - 1);

                    if (addToNextCalculation)
                    {
                        tempNumber++;
                    }

                    if (tempNumber < 10)
                    {
                        resultNumber.Insert(0, tempNumber);
                        addToNextCalculation = false;
                    }
                    else
                    {
                        resultNumber.Insert(0, tempNumber % 10);
                        addToNextCalculation = true;
                    }
                }
            }
            else
            {
                while (secondNumber.Length > 0)
                {
                    int tempNumber = int.Parse(secondNumber.Substring(secondNumber.Length - 1, 1));

                    secondNumber = secondNumber.Remove(secondNumber.Length - 1);

                    if (addToNextCalculation)
                    {
                        tempNumber++;
                    }

                    if (tempNumber < 10)
                    {
                        resultNumber.Insert(0, tempNumber);
                        addToNextCalculation = false;
                    }
                    else
                    {
                        resultNumber.Insert(0, tempNumber % 10);
                        addToNextCalculation = true;
                    }
                }
            }

            if (addToNextCalculation)
            {
                resultNumber.Insert(0, 1);
            }

            return resultNumber.ToString();
        }
    }
}