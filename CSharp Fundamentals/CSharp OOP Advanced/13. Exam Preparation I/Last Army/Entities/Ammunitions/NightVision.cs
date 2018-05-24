public class NightVision : Ammunition
{
    public const double WEIGHT = 0.8;
    public const string NAME = nameof(NightVision);

    public NightVision()
        : base(NAME, WEIGHT)
    {
    }
}
