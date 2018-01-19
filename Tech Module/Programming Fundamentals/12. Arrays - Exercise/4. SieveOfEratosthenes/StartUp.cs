namespace SieveOfEratosthenes
{
    using System;
    using System.Linq;

    public class SieveOfEratosthenes
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primesArray = new bool[n + 1].Select(x => true).ToArray();

            primesArray[0] = false;
            primesArray[1] = false;

            for (int i = 2; i < primesArray.Length; i++)
            {
                if (primesArray[i])
                {
                    for (int j = i; j < primesArray.Length; j += i)
                    {
                        primesArray[j] = false;
                    }

                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}