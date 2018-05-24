using System;
using System.Text;

public class StartUp
{
    public static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);
            IPerson person = new Citizen(name, country, age);
            IResident resident = new Citizen(name, country, age);

            sb.AppendLine(person.GetName());
            sb.AppendLine(resident.GetName());

            input = Console.ReadLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }   
}

