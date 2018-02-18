public class Person
{
    private string name;
    private int age;

    public Person(string nameGiven, int ageGiven)
    {
        this.Name = nameGiven;
        this.Age = ageGiven;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}

