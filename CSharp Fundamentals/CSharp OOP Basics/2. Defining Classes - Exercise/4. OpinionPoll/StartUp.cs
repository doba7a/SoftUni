using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Person[] personData = new Person[numberOfInputs];

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person(inputData[0], int.Parse(inputData[1]));

            personData[i] = currentPerson;
        }

        foreach (Person person in personData.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

