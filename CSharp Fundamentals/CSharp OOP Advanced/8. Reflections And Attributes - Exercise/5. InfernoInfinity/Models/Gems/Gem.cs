public abstract class Gem : IGem
{
    private int strength;
    private int agility;
    private int vitality;

    protected Gem(Clarity gemClarity, int strength, int agility, int vitality)
    {
        this.Strength = strength + (int)gemClarity;
        this.Agility = agility + (int)gemClarity;
        this.Vitality = vitality + (int)gemClarity;
    }

    public int Strength { get => strength; private set => strength = value; }
    public int Agility { get => agility; private set => agility = value; }
    public int Vitality { get => vitality; private set => vitality = value; }
}

