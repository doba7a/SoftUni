namespace NumbersInReversedOrder
{
    using System;
    using System.Linq;

    public class NumbersInReversedOrder
    {
        public static void Main()
        {
            double givenNumber = double.Parse(Console.ReadLine());

            double reversedNumber = ReverseNum(givenNumber);

            Console.WriteLine(reversedNumber);
        }

        public static double ReverseNum(double givenNumber)
        {
            char[] reversedNumAsCharArray = givenNumber.ToString().Reverse().ToArray();

            string reversedNumAsString = string.Empty;

            foreach (var digit in reversedNumAsCharArray)
            {
                reversedNumAsString += digit;
            }

            double reversedNum = double.Parse(reversedNumAsString);

            return reversedNum;
        }
    }
}