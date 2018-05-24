public class Emerald : Gem
{
    private const int EMERALD_STRENGTH = 1;
    private const int EMERALD_AGILITY = 4;
    private const int EMERALD_VITALITY = 9;

    public Emerald(Clarity clarity)
        : base(clarity, EMERALD_STRENGTH, EMERALD_AGILITY, EMERALD_VITALITY)
    {
    }
}

