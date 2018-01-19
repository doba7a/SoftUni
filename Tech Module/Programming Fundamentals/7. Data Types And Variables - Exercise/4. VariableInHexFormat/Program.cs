namespace VariableInHexFormat
{
    using System;

    public class VariableInHexFormat
    {
        public static void Main()
        {
            string firstNumber = Console.ReadLine();
            int numberOne = Convert.ToInt32(firstNumber, 16);
            Console.WriteLine(numberOne);
        }
    }
}