public abstract class Ammunition : IAmmunition
{
    private const double WEAR_LEVEL_MULTIPLIER = 100;

    private string name;
    private double weight;

    protected Ammunition(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
        this.WearLevel = weight * WEAR_LEVEL_MULTIPLIER;
    }

    public string Name => this.name;

    public double Weight => this.weight;

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}