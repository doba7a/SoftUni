﻿public class Employee
{
    public Employee(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.Name}";
    }
}

