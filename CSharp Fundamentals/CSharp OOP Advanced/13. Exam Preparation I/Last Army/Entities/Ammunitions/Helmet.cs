public class Helmet : Ammunition
{
    public const double WEIGHT = 2.3;
    public const string NAME = nameof(Helmet);

    public Helmet()
        : base(NAME, WEIGHT)
    {
    }
}
