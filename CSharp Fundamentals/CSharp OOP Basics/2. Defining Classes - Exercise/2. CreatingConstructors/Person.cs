public class Person
{
    private string name;
    private int age;

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int ageGiven)
        : this()
    {
        this.Age = ageGiven;
    }

    public Person(string nameGiven, int ageGiven)
        : this(ageGiven)
    {
        this.Name = nameGiven;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}