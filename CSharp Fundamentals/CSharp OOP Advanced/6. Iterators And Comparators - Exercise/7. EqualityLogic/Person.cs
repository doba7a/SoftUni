using System;

public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get => name; private set => name = value; }
    public int Age { get => age; private set => age = value; }

    public int CompareTo(Person other)
    {
        int result = this.name.CompareTo(other.name);

        if (result == 0)
        {
            result = this.age.CompareTo(other.age);
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        Person person = obj as Person;

        return this.Name == person.Name && this.Age == person.Age;
    }

    public override int GetHashCode()
    {
        return this.Age.GetHashCode() + this.Name.GetHashCode();
    }
}
