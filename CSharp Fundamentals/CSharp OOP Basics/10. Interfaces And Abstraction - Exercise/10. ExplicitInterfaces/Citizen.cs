﻿public class Citizen : IResident, IPerson
{
    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    public string Name { get; private set; }

    public string Country { get; private set; }

    public int Age { get; private set; }

    public string GetName()
    {
        return $"Mr/Ms/Mrs {Name}";
    }

    string IPerson.GetName()
    {
        return Name;
    }
}

