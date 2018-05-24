using System;
using System.Linq;
using System.Text;

public class Engine
{
    private PetClinicsController manager;

    public Engine()
    {
        this.manager = new PetClinicsController();
    }

    public string Run()
    {
        StringBuilder sb = new StringBuilder();

        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine().Split(' ');
            string command = inputData[0];
            string[] args = inputData.Skip(1).ToArray();

            try
            {
                switch (command)
                {
                    case "Create":
                        manager.Create(args);
                        break;
                    case "Add":
                        string addResult = manager.Add(args).ToString();
                        sb.AppendLine(addResult);
                        break;
                    case "Release":
                        string releaseResult = manager.Release(args).ToString();
                        sb.AppendLine(releaseResult);
                        break;
                    case "HasEmptyRooms":
                        string hasEmptyRoomsResult = manager.HasEmptyRooms(args).ToString();
                        sb.AppendLine(hasEmptyRoomsResult);
                        break;
                    case "Print":
                        string printResult = manager.Print(args);
                        sb.AppendLine(printResult);
                        break;
                }
            }
            catch (InvalidOperationException ioe)
            {
                sb.AppendLine(ioe.Message);
            }
        }

        return sb.ToString().Trim();
    }
}

