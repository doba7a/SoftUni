public class Knife : Ammunition
{
    public const double WEIGHT = 0.4;
    public const string NAME = nameof(Knife);

    public Knife()
        : base(NAME, WEIGHT)
    {
    }
}
