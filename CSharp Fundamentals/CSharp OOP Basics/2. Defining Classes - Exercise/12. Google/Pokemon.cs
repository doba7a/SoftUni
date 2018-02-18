using System;

public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string nameGiven, string typeGiven)
    {
        this.Name = nameGiven;
        this.Type = typeGiven;
    }

    public string Name { get => name; set => name = value; }
    public string Type { get => type; set => type = value; }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}{Environment.NewLine}";
    }
}
