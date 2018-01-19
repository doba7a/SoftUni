namespace _14.IntegerToHexAndBinary
{
    using System;

    public class IntegerToHexAndBinary
    {
        public static void Main()
        {
            int[] bases = { 16, 2 };
            int number = int.Parse(Console.ReadLine());

            foreach (int baseValue in bases)
            {
                Console.WriteLine("{0}", Convert.ToString(number, baseValue).ToUpper());
            }
        }
    }
}