namespace AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Func<double, double> vatValues = n => n * 1.20;

            foreach (double number in numbers)
            {
                Console.WriteLine($"{vatValues(number):F2}");
            }
        }
    }
}
