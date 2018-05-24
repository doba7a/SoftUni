using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Robot> robots = new List<Robot>();
        List<IBirthable> birthables = new List<IBirthable>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            switch (inputData[0])
            {
                case "Citizen":
                    AddCitizen(birthables, inputData);
                    break;
                case "Robot":
                    AddRobot(robots, inputData);
                    break;
                case "Pet":
                    AddPet(birthables, inputData);
                    break;
            }

            input = Console.ReadLine();
        }

        string yearGiven = Console.ReadLine();

        foreach (var birthable in birthables)
        {
            if (birthable.Birthdate.EndsWith(yearGiven))
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }

    private static void AddCitizen(List<IBirthable> birthables, string[] citizenData)
    {
        Citizen citizen = new Citizen(citizenData[1], int.Parse(citizenData[2]), citizenData[3], citizenData[4]);

        birthables.Add(citizen);
    }

    private static void AddRobot(List<Robot> robots, string[] robotData)
    {
        Robot robot = new Robot(robotData[1], robotData[2]);

        robots.Add(robot);
    }

    private static void AddPet(List<IBirthable> birthables, string[] petData)
    {
        Pet pet = new Pet(petData[1], petData[2]);

        birthables.Add(pet);
    }
}



