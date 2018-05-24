public class RPG : Ammunition
{
    public const double WEIGHT = 17.1;
    public const string NAME = nameof(RPG);

    public RPG()
        : base(NAME, WEIGHT)
    {
    }
}
