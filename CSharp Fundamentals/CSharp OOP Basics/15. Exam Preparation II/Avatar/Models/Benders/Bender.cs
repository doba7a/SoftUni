public abstract class Bender
{
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get => name; protected set => name = value; }
    public int Power { get => power; protected set => power = value; }

    public abstract double GetBenderPower();
}

