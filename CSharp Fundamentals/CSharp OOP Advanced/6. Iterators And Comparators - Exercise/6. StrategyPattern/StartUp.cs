using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        SortedSet<Person> nameSet = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ageSet = new SortedSet<Person>(new AgeComparator());

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] currentPersonData = Console.ReadLine().Split(' ');

            Person currentPerson = new Person(currentPersonData[0], int.Parse(currentPersonData[1]));

            nameSet.Add(currentPerson);
            ageSet.Add(currentPerson);
        }

        foreach (Person person in nameSet)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
        foreach (Person person in ageSet)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}

