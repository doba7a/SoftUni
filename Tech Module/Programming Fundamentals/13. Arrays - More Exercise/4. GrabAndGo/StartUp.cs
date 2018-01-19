namespace GrabAndGo
{
    using System;
    using System.Linq;

    public class GrabAndGo
    {
        public static void Main()
        {
            int[] arrayOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int integerToSearchFor = int.Parse(Console.ReadLine());

            if (arrayOfIntegers.Contains(integerToSearchFor))
            {
                int lastIndexOfSearchedInteger =  Array.LastIndexOf(arrayOfIntegers, integerToSearchFor);

                long sum = 0;

                for (int i = 0; i < lastIndexOfSearchedInteger; i++)
                {
                    sum += arrayOfIntegers[i];
                }

                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}