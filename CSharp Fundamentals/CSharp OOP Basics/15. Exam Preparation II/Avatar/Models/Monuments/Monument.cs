public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get => name; protected set => name = value; }

    public abstract int GetMonumentPower();
}

