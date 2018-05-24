public class Amethyst : Gem
{
    private const int AMETHYST_STRENGTH = 2;
    private const int AMETHYST_AGILITY = 8;
    private const int AMETHYST_VITALITY = 4;

    public Amethyst(Clarity clarity)
        : base(clarity, AMETHYST_STRENGTH, AMETHYST_AGILITY, AMETHYST_VITALITY)
    {
    }
}

