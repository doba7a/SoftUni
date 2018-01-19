namespace ArrayManipulator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class ArrayManipulator
    {
        public static void Main()
        {
            List<int> listOfIntegers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string[] currentCommandData = Console.ReadLine().Split(' ');

            while (currentCommandData[0] != "print")
            {
                switch (currentCommandData[0])
                {
                    case "add":
                        int indexToInsertAt = int.Parse(currentCommandData[1]);
                        int integerToInsert = int.Parse(currentCommandData[2]);

                        listOfIntegers.Insert(indexToInsertAt, integerToInsert);

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;

                    case "addMany":
                        int startingIndex = int.Parse(currentCommandData[1]);
                        List<int> integersToAdd = currentCommandData.Skip(2).Select(int.Parse).ToList();

                        listOfIntegers.InsertRange(startingIndex, integersToAdd);

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;

                    case "contains":
                        int elementToContain = int.Parse(currentCommandData[1]);

                        if (listOfIntegers.Contains(elementToContain))
                        {
                            Console.WriteLine(listOfIntegers.IndexOf(elementToContain));
                        }
                        else
                        {
                            Console.WriteLine("-1");
                        }

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;

                    case "remove":
                        int indexToRemove = int.Parse(currentCommandData[1]);

                        listOfIntegers.RemoveAt(indexToRemove);

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;

                    case "shift":
                        int rotations = int.Parse(currentCommandData[1]);

                        for (int i = 0; i < rotations; i++)
                        {
                            int firstElement = listOfIntegers[0];
                            listOfIntegers.RemoveAt(0);
                            listOfIntegers.Add(firstElement);
                        }

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;

                    case "sumPairs":
                        for (int i = 0; i < listOfIntegers.Count - 1; i++)
                        {
                            listOfIntegers[i] += listOfIntegers[i + 1];
                            listOfIntegers.RemoveAt(i + 1);
                        }

                        currentCommandData = Console.ReadLine().Split(' ');
                        break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", listOfIntegers) + "]");
        }
    }
}