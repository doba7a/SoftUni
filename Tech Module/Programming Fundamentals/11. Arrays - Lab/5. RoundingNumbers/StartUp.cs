namespace RoundingNumbers
{
    using System;
    using System.Linq;

    public class RoundingNumbers
    {
        public static void Main()
        {
            double[] arrayOfDoubles = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            foreach (double number in arrayOfDoubles)
            {
                double givenNumber = number;
                double roundedNumber = Math.Round(number, MidpointRounding.AwayFromZero);

                Console.WriteLine($"{givenNumber} => {roundedNumber}");
            }
        }
    }
}