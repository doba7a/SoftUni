using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Engine
{
    private static List<ISoldier> soldiers = new List<ISoldier>();

    public static void Read(string input)
    {
        while (input != "End")
        {
            try
            {

                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                double salary = double.Parse(tokens[4]);

                switch (type)
                {
                    case "Private":
                        TryAddPrivate(id, firstName, lastName, salary);
                        break;
                    case "LeutenantGeneral":
                        TryAddLeutenantGeneral(id, firstName, lastName, salary, tokens);
                        break;
                    case "Engineer":
                        TryAddEngineer(id, firstName, lastName, salary, tokens);
                        break;
                    case "Commando":
                        TryAddCommando(id, firstName, lastName, salary, tokens);
                        break;
                    case "Spy":
                        TryAddSpy(id, firstName, lastName, (int)salary);
                        break;
                }
            }
            catch (Exception)
            { }

            input = Console.ReadLine();
        }

        OutputWritter.Print(soldiers);
    }

    private static void TryAddSpy(int id, string firstName, string lastName, int codeNumber)
    {
        Spy spy = new Spy(id, firstName, lastName, codeNumber);
        soldiers.Add(spy);
    }

    private static void TryAddCommando(int id, string firstName, string lastName, double salary, string[] tokens)
    {
        string corps = tokens[5];
        Commando commando = new Commando(id, firstName, lastName, salary, corps);
        for (int i = 6; i < tokens.Length; i += 2)
        {
            try
            {
                string missionCodeName = tokens[i];
                string missionState = tokens[i + 1];
                Mission repair = new Mission(missionCodeName, missionState);
                commando.AddRepair(repair);
            }
            catch (Exception) { }
        }
        soldiers.Add(commando);
    }

    private static void TryAddEngineer(int id, string firstName, string lastName, double salary, string[] tokens)
    {
        string corps = tokens[5];
        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

        for (int i = 6; i < tokens.Length; i += 2)
        {
            try
            {
                string part = tokens[i];
                int hours = int.Parse(tokens[i + 1]);
                Repair repair = new Repair(part, hours);
                engineer.AddRepair(repair);
            }
            catch (Exception) { }
        }
        soldiers.Add(engineer);
    }

    private static void TryAddLeutenantGeneral(int id, string firstName, string lastName, double salary, string[] tokens)
    {
        LeutenantGeneral leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, salary);

        for (int i = 5; i < tokens.Length; i++)
        {
            try
            {
                int currentId = int.Parse(tokens[i]);
                var currentPrivate = soldiers.FirstOrDefault(x => x.Id == currentId);
                leutenantGeneral.AddPrivate((IPrivate)currentPrivate);
            }
            catch (Exception) { }
        }
        soldiers.Add(leutenantGeneral);
    }

    private static void TryAddPrivate(int id, string firstName, string lastName, double salary)
    {
        Private currentPrivate = new Private(id, firstName, lastName, salary);
        soldiers.Add(currentPrivate);
    }
}

