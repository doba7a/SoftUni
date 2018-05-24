public class Citizen : IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    private int food;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.name = name;
        this.age = age;
        this.id = id;
        this.birthdate = birthdate;
        this.Food = 0;
    }

    public int Food { get => food; set => food = value; }
    public string Name { get => name; private set => name = value; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}

