using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder manager;

    public Engine()
    {
        this.manager = new NationsBuilder();
    }

    public void Run()
    {
        while (true)
        {
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> commandParameters = command.Skip(1).ToList();

            switch (command[0])
            {
                case "Bender":
                    this.manager.AssignBender(commandParameters);
                    break;
                case "Monument":
                    this.manager.AssignMonument(commandParameters);
                    break;
                case "Status":
                    string status = this.manager.GetStatus(commandParameters[0]);
                    Console.WriteLine(status);
                    break;
                case "War":
                    this.manager.IssueWar(commandParameters[0]);
                    break;
                case "Quit":
                    string warsData = this.manager.GetWarsRecord();
                    Console.WriteLine(warsData);
                    return;
            }
        }
    }
}

