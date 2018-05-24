using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IList<string> arguments;

    protected Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments { get => arguments; protected set => arguments = value; }

    public abstract string Execute();
}

