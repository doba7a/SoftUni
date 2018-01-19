namespace MaxMethod
{
    using System;

    public class MaxMethod
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int biggestValue = GetMax(firstNumber, GetMax(secondNumber, thirdNumber));

            Console.WriteLine(biggestValue);
        }

        public static int GetMax(int firstNumber, int secondNumber)
        {
            int biggerValue = Math.Max(firstNumber, secondNumber);

            return biggerValue;
        }
    }
}