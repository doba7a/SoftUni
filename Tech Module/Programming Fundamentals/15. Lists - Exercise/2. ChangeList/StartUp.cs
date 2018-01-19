namespace ChangeList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ChangeList
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string currentCommandData = Console.ReadLine();

            while (currentCommandData != "Even" && currentCommandData != "Odd")
            {
                string currentCommand = currentCommandData.Split(' ')[0];

                if (currentCommand == "Delete")
                {
                    int integerToDelete = int.Parse(currentCommandData.Split(' ')[1]);

                    listOfIntegers.RemoveAll(x => x == integerToDelete);
                }
                else
                {
                    int integerToInsert = int.Parse(currentCommandData.Split(' ')[1]);
                    int indexToInsertAt = int.Parse(currentCommandData.Split(' ')[2]);

                    listOfIntegers.Insert(indexToInsertAt, integerToInsert);
                }

                currentCommandData = Console.ReadLine();
            }

            if (currentCommandData == "Even")
            {
                Console.WriteLine(string.Join(" ",listOfIntegers.Where(x => x % 2 == 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", listOfIntegers.Where(x => x % 2 == 1)));
            }
        }
    }
}