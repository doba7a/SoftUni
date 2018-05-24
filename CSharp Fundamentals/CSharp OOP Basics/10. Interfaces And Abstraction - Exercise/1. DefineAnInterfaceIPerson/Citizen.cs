public class Citizen : IPerson
{
    private string name;
    private int age;

    public Citizen(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name { get => name; private set => name = value; }
    public int Age { get => age; private set => age = value; }
}