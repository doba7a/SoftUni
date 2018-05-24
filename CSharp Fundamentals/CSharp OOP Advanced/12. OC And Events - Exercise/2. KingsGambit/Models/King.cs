using System;

public class King : IIdentifiable, IAttackable
{
    public event EventHandler RespondToAttackEventHandler;

    private string name;

    public King(string name)
    {
        this.Name = name;
    }

    public string Name { get => name; private set => name = value; }

    public void RespondToAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        this.RespondToAttackEventHandler?.Invoke(this, EventArgs.Empty);
    }
}

