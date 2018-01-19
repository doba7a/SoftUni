namespace BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BombNumbers
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> bombData = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int bombNumber = bombData[0];
            int bombPower = bombData[1];

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if (listOfIntegers[i] == bombNumber)
                {
                    int startIndex = Math.Max(0, i - bombPower);
                    int endIndex = Math.Min(i + bombPower, listOfIntegers.Count - 1);
                    int length = endIndex - startIndex + 1;

                    listOfIntegers.RemoveRange(startIndex, length);

                    i = 0;
                }
            }

            Console.WriteLine(listOfIntegers.Sum());
        }
    }
}