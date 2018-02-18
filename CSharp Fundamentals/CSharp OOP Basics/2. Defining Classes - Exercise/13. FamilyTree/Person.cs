using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private string birthDate;
    private List<Person> children;

    public Person()
    {
        this.children = new List<Person>();
    }

    public Person(string nameGiven, string birthDateGiven) : this()
    {
        this.Name = nameGiven;
        this.BirthDate = birthDateGiven;
    }


    public IReadOnlyList<Person> Children => this.children.AsReadOnly();
    public string BirthDate { get => birthDate; set => birthDate = value; }
    public string Name { get => name; set => name = value; }

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }

    public void AddChildrenInfo(string name, string birthdate)
    {
        if (this.children.FirstOrDefault(c => c.Name == name) != null)
        {
            this.children
                .FirstOrDefault(c => c.Name == name)
                .BirthDate = birthdate;
            return;
        }
        if (this.children.FirstOrDefault(c => c.BirthDate == birthdate) != null)
        {
            this.children
                .FirstOrDefault(c => c.BirthDate == birthdate)
                .Name = name;
        }
    }

    public Person FindChild(string childName)
    {
        return this.children.FirstOrDefault(c => c.Name == childName);
    }
}