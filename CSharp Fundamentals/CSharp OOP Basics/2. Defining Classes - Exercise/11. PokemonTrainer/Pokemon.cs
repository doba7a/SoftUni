public class Pokemon
{
    private string name;
    private string element;
    private int health;

    public Pokemon(string nameGiven, string elementGiven, int healthGiven)
    {
        this.Name = nameGiven;
        this.Element = elementGiven;
        this.Health = healthGiven;
    }

    public string Name { get => name; set => name = value; }
    public string Element { get => element; set => element = value; }
    public int Health { get => health; set => health = value; }
}

