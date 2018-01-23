namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            int decimalInput = int.Parse(Console.ReadLine());

            if (decimalInput == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(1);
            }

            Stack<byte> stack = new Stack<byte>();

            while (decimalInput > 0)
            {
                byte remainder = (byte)(decimalInput % 2);

                stack.Push(remainder);

                decimalInput /= 2;
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
