using System;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }

    public void Run()
    {
        while (true)
        {
            string[] inputData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = inputData[0];

            switch (command)
            {
                case "register":
                    this.manager.Register(int.Parse(inputData[1]), inputData[2], inputData[3], inputData[4], int.Parse(inputData[5]), 
                        int.Parse(inputData[6]), int.Parse(inputData[7]), int.Parse(inputData[8]), int.Parse(inputData[9]));
                    break;
                case "check":
                    string checkOutput = this.manager.Check(int.Parse(inputData[1]));
                    Console.WriteLine(checkOutput);
                    break;
                case "open":
                    if (inputData.Length == 6)
                    {
                        this.manager.Open(int.Parse(inputData[1]), inputData[2], int.Parse(inputData[3]), inputData[4], int.Parse(inputData[5]), 0);
                    }
                    else if (inputData.Length == 7)
                    {
                        this.manager.Open(int.Parse(inputData[1]), inputData[2], int.Parse(inputData[3]), inputData[4], int.Parse(inputData[5]), int.Parse(inputData[6]));
                    }
                    break;
                case "participate":
                    this.manager.Participate(int.Parse(inputData[1]), int.Parse(inputData[2]));
                    break;
                case "start":
                    string raceOutput = this.manager.Start(int.Parse(inputData[1]));
                    Console.WriteLine(raceOutput);
                    break;
                case "park":
                    this.manager.Park(int.Parse(inputData[1]));
                    break;
                case "unpark":
                    this.manager.Unpark(int.Parse(inputData[1]));
                    break;
                case "tune":
                    this.manager.Tune(int.Parse(inputData[1]), inputData[2]);
                    break;
                case "Cops":
                    return;
            }
        }
    }
}

