using System;

public class NameChangeEventArgs : EventArgs
{
    private string name;

    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name { get => name; private set => name = value; }
}
