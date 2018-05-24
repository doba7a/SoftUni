public class Rebel : IBuyer
{
    private string name;
    private int age;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.age = age;
        this.group = group;
        this.Food = 0;
    }

    public int Food { get => food; set => food = value; }
    public string Name { get => name; private set => name = value; }

    public void BuyFood()
    {
        this.Food += 5;
    }
}

