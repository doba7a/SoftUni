public abstract class Command : ICommand
{
    private string[] data;

    protected Command(string[] data)
    {
        this.Data = data;
    }

    public string[] Data { get => data; private set => data = value; }

    public abstract void Execute();
}

