public class Gun : Ammunition
{
    public const double WEIGHT = 1.4;
    public const string NAME = nameof(Gun);

    public Gun()
        : base(NAME, WEIGHT)
    {
    }
}
