﻿namespace DifferentIntegersSize
{
    using System;
    using System.Numerics;

    public class DifferentIntegersSize
    {
        public static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());

            if (number >= -9223372036854775808 && number <= 9223372036854775807)
            {
                Console.WriteLine($"{number} can fit in:");
                if (number >= -128 && number <= 127)
                {
                    Console.WriteLine("* sbyte");
                }
                if (number >= 0 && number <= 255)
                {
                    Console.WriteLine("* byte");
                }
                if (number >= -32768 && number <= 32767)
                {
                    Console.WriteLine("* short");
                }
                if (number >= 0 && number <= 65535)
                {
                    Console.WriteLine("* ushort");
                }
                if (number >= -2147483648 && number <= 2147483647)
                {
                    Console.WriteLine("* int");
                }
                if (number >= 0 && number <= 4294967295)
                {
                    Console.WriteLine("* uint");
                }
                if (number >= -9223372036854775808 && number <= 9223372036854775807)
                {
                    Console.WriteLine("* long");
                }
            }
            else
            {
                Console.WriteLine($"{number} can't fit in any type");
            }

        }
    }
}