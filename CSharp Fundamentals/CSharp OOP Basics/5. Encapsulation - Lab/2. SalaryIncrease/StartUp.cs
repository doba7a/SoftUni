using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Person[] personsData = new Person[numberOfInputs];

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person(inputData[0], inputData[1], int.Parse(inputData[2]), decimal.Parse(inputData[3]));

            personsData[i] = currentPerson;
        }

        decimal percentIncrease = decimal.Parse(Console.ReadLine());

        foreach (Person person in personsData)
        {
            person.IncreaseSalary(percentIncrease);
            Console.WriteLine(person.ToString());
        }
    }
}

