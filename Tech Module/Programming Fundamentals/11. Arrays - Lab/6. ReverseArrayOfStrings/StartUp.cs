namespace ReverseArrayOfStrings
{
    using System;
    using System.Linq;

    public class ReverseArrayOfStrings
    {
        public static void Main()
        {
            string[] arrayOfStrings = Console.ReadLine().Split(' ').ToArray();

            Array.Reverse(arrayOfStrings);

            Console.WriteLine(string.Join(" ", arrayOfStrings));
        }
    }
}