using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<IInhabitant> inhabitants = new List<IInhabitant>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            if (inputData.Length == 3)
            {
                AddCitizen(inhabitants, inputData);
            }
            else if (inputData.Length == 2)
            {
                AddRobot(inhabitants, inputData);
            }

            input = Console.ReadLine();
        }

        string lastDigitsOfFakeIds = Console.ReadLine();

        foreach (var inhabitant in inhabitants)
        {
            if (inhabitant.ValidId(inhabitant.Id, lastDigitsOfFakeIds))
            {
                continue;
            }
            else
            {
                Console.WriteLine(inhabitant.Id);
            }
        }
    }

    private static void AddCitizen(List<IInhabitant> inhabitants, string[] citizenData)
    {
        Citizen citizen = new Citizen(citizenData[0], int.Parse(citizenData[1]), citizenData[2]);

        inhabitants.Add(citizen);
    }

    private static void AddRobot(List<IInhabitant> inhabitants, string[] robotData)
    {
        Robot robot = new Robot(robotData[0], robotData[1]);

        inhabitants.Add(robot);
    }
}

