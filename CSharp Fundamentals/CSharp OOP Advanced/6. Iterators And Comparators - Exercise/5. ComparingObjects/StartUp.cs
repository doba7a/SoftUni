using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        IList<Person> personData = new List<Person>();

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] currentPersonData = input.Split(' ');

            Person currentPerson = new Person(currentPersonData[0], int.Parse(currentPersonData[1]), currentPersonData[2]);

            personData.Add(currentPerson);

            input = Console.ReadLine();
        }

        int index = int.Parse(Console.ReadLine()) - 1;

        Person personToCompare = personData[index];
        int numberOfEqualPeople = 0;
        int numberOfNonEqualPeople = 0;

        for (int i = 0; i < personData.Count; i++)
        {
            if (personToCompare.CompareTo(personData[i]) == 0)
            {
                numberOfEqualPeople++;
            }
            else
            {
                numberOfNonEqualPeople++;
            }
        }

        if (numberOfEqualPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{numberOfEqualPeople} {numberOfNonEqualPeople} {personData.Count}");
        }
    }
}

