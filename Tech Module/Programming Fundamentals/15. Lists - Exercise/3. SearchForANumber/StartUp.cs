namespace SearchForANumber
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SearchForANumber
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> inputData = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int elementsToTake = inputData[0];
            int elementsToDelete = inputData[1];
            int integerToSearchFor = inputData[2];

            List<int> tempList = listOfIntegers.Take(elementsToTake).ToList();
            tempList.RemoveRange(0, elementsToDelete);

            if (tempList.Contains(integerToSearchFor))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}