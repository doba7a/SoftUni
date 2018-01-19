namespace JumpAround
{
    using System;
    using System.Linq;

    public class JumpAround
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;
            int currentIndex = 0;

            while (true)
            {
                sum += arrayOfIntegers[currentIndex];

                if (currentIndex + arrayOfIntegers[currentIndex] < arrayOfIntegers.Length)
                {
                    currentIndex += arrayOfIntegers[currentIndex];
                    continue;
                }
                else if (currentIndex - arrayOfIntegers[currentIndex] >= 0)
                {
                    currentIndex -= arrayOfIntegers[currentIndex];
                    continue;
                }

                break;
            }

            Console.WriteLine(sum);
        }
    }
}