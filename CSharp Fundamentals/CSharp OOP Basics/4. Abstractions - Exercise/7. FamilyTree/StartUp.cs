using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        string personToPrintAbout = Console.ReadLine();

        string input = Console.ReadLine();

        while (input != "End")
        {
            if (input.Contains("-"))
            {
                string[] inputData = input
                            .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();

                string parentData = inputData[0];
                string childData = inputData[1];

                Person parent = CreatePerson(parentData);
                Person child = CreatePerson(childData);

                AddParentIfMissing(people, parent);

                if (parent.Name != null)
                {
                    people.FirstOrDefault(p => p.Name == parent.Name).AddChild(child);
                }
                else
                {
                    people.FirstOrDefault(p => p.BirthDate == parent.BirthDate).AddChild(child);
                }
            }
            else
            {
                string[] inputData = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = $"{inputData[0]} {inputData[1]}";
                string birthdate = inputData[2];

                bool isExistingPerson = false;

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == name)
                    {
                        people[i].BirthDate = birthdate;
                        isExistingPerson = true;
                    }

                    if (people[i].BirthDate == birthdate)
                    {
                        people[i].Name = name;
                        isExistingPerson = true;
                    }

                    people[i].AddChildrenInfo(name, birthdate);
                }

                if (!isExistingPerson)
                {
                    people.Add(new Person(name, birthdate));
                }
            }

            input = Console.ReadLine();
        }

        PrintParentsAndChildren(people, personToPrintAbout);
    }

    private static Person CreatePerson(string personParam)
    {
        Person person = new Person();

        if (IsDate(personParam))
        {
            person.BirthDate = personParam;
        }
        else
        {
            person.Name = personParam;
        }

        return person;
    }

    private static void PrintParentsAndChildren(List<Person> people, string personParam)
    {
        Person person = people.FirstOrDefault(p => p.BirthDate == personParam || p.Name == personParam);

        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{person.Name} {person.BirthDate}");

        builder.AppendLine("Parents:");
        people.Where(p => p.FindChild(person.Name) != null)
              .ToList()
              .ForEach(p => builder.AppendLine($"{p.Name} {p.BirthDate}"));

        builder.AppendLine("Children:");
        person.Children
              .ToList()
              .ForEach(c => builder.AppendLine($"{c.Name} {c.BirthDate}"));

        Console.WriteLine(builder.ToString().TrimEnd());
    }

    private static void AddParentIfMissing(List<Person> people, Person parent)
    {
        if ((parent.Name != null && people.Any(p => p.Name == parent.Name)) ||
            (parent.BirthDate != null & people.Any(p => p.BirthDate == parent.BirthDate)))
        {
            return;
        }

        people.Add(parent);
    }

    public static bool IsDate(string s)
    {
        return s.Contains("/");
    }
}
