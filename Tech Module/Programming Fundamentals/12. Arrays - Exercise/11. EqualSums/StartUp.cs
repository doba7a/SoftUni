namespace EqualSums
{
    using System;
    using System.Linq;

    public class EqualSums
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < arrayOfIntegers.Length; i++)
            {
                int leftSum = arrayOfIntegers.Take(i).ToArray().Sum();

                int rightSum = arrayOfIntegers.Skip(i + 1).ToArray().Sum();

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    Environment.Exit(1);
                }
            }

            Console.WriteLine("no");
        }
    }
}