using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(string nameGiven)
    {
        this.Name = nameGiven;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name { get => name; set => name = value; }
    public int Badges { get => badges; set => badges = value; }
    public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }
}

