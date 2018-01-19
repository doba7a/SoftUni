namespace TriplesSum
{
    using System;
    using System.Linq;

    public class TriplesSum
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool foundTriplet = false;

            for (int a = 0; a < arrayOfIntegers.Length - 1; a++)
            {
                for (int b = a + 1; b < arrayOfIntegers.Length; b++)
                {
                    int c = arrayOfIntegers[a] + arrayOfIntegers[b];

                    if (arrayOfIntegers.Contains(c))
                    {
                        Console.WriteLine($"{arrayOfIntegers[a]} + {arrayOfIntegers[b]} == {c}");
                        foundTriplet = true;
                    }
                }
            }

            if (!foundTriplet)
            {
                Console.WriteLine("No");
            }
        }
    }
}