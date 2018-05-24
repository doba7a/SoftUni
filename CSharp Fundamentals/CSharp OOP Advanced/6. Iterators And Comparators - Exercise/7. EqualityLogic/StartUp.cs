using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] currentPersonData = Console.ReadLine().Split(' ');

            Person currentPerson = new Person(currentPersonData[0], int.Parse(currentPersonData[1]));

            sortedSet.Add(currentPerson);
            hashSet.Add(currentPerson);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}

