using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Name { get => name; private set => name = value; }
    public int Age { get => age; private set => age = value; }
    public string Town { get => town; private set => town = value; }

    public int CompareTo(Person other)
    {
        if (this.Name == other.Name && this.Age == other.Age && this.Town == other.Town)
        {
            return 0;
        }

        return -1;
    }
}

