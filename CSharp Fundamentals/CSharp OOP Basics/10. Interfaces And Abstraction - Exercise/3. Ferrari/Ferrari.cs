public class Ferrari : ICar
{
    private const string Model = "488-Spider";
    private string name;

    public Ferrari(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{Brake()}/{Gas()}/{this.name}";
    }
}


