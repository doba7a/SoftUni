public class Pet : IPet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int age, string type)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = type;
    }

    public string Name { get => name; private set => name = value; }
    public int Age { get => age; private set => age = value; }
    public string Kind { get => kind; private set => kind = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}

