public abstract class Identificator
{
    private string id;

    protected Identificator(string id)
    {
        this.Id = id;
    }

    public string Id { get => id; protected set => id = value; }
}

