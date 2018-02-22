using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Person[] personsData = new Person[numberOfInputs];

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person(inputData[0], inputData[1], int.Parse(inputData[2]));

            personsData[i] = currentPerson;
        }

        personsData.OrderBy(p => p.FirstName)
           .ThenBy(p => p.Age)
           .ToArray();


        foreach (Person person in personsData)
        {
            Console.WriteLine(person.ToString());
        }
    }
}