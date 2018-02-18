public class Cargo
{
    private int weight;
    private string type;

    public Cargo(int weightGiven, string typeGiven)
    {
        this.Weight = weightGiven;
        this.Type = typeGiven;
    }

    public int Weight { get => weight; set => weight = value; }
    public string Type { get => type; set => type = value; }
}

