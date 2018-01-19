namespace ExtractMiddleElements
{
    using System;
    using System.Linq;

    public class ExtractMiddleElements
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = arrayOfIntegers.Length;

            if (length == 1)
            {
                Console.WriteLine($"{{ {arrayOfIntegers[0]} }}");
            }
            else if (length % 2 == 0)
            {
                Console.WriteLine($"{{ {arrayOfIntegers[length / 2 - 1]}, {arrayOfIntegers[length / 2]} }}");
            }
            else
            {
                Console.WriteLine($"{{ {arrayOfIntegers[length / 2 - 1]}, {arrayOfIntegers[length / 2]}, {arrayOfIntegers[length / 2 + 1]} }}");
            }
        }
    }
}