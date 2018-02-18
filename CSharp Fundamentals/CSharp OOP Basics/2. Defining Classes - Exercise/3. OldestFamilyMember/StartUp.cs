using System;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Family familyData = new Family();

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] currentPersonData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = new Person(currentPersonData[0], int.Parse(currentPersonData[1]));

            familyData.FamilyMembers.Add(currentPerson);
        }

        Person oldestMember = familyData.GetOldestMember();

        if (oldestMember != null)
        {
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}

