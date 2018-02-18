using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Child> children;
    private Car car;

    public Person(string nameGiven)
    {
        this.Name = nameGiven;
        this.Company = null;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
        this.Car = null;
    }

    public string Name { get => name; set => name = value; }
    public Company Company { get => company; set => company = value; }
    public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }
    public List<Parent> Parents { get => parents; set => parents = value; }
    public List<Child> Children { get => children; set => children = value; }
    public Car Car { get => car; set => car = value; }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        output.Append($"{this.Name}{Environment.NewLine}");

        output.Append($"Company:{Environment.NewLine}");
        if (this.Company != null)
        {
            output.Append(Company);
        }

        output.Append($"Car:{Environment.NewLine}");
        if (this.Car != null)
        {
            output.Append(Car);
        }

        output.Append($"Pokemon:{Environment.NewLine}");
        if (this.Pokemons != null)
        {
            foreach (Pokemon pokemon in this.Pokemons)
            {
                output.Append(pokemon);
            }
        }

        output.Append($"Parents:{Environment.NewLine}");
        if (this.Parents != null)
        {
            foreach (Parent parent in this.Parents)
            {
                output.Append(parent);
            }
        }

        output.Append($"Children:{Environment.NewLine}");
        if (this.Children != null)
        {
            foreach (Child child in this.Children)
            {
                output.Append(child);
            }
        }

        return output.ToString().TrimEnd();
    }
}
