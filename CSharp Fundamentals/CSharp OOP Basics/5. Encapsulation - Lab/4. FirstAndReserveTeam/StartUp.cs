using System;

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

        Team plovdivTeam = new Team("pLOVEdiv");

        foreach (Person person in personsData)
        {
            plovdivTeam.AddPlayer(person);
        }

        Console.WriteLine($"First team has {plovdivTeam.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {plovdivTeam.ReserveTeam.Count} players.");
    }
}

