public class AutomaticMachine : Ammunition
{
    public const double WEIGHT = 6.3;
    public const string NAME = nameof(AutomaticMachine);

    public AutomaticMachine()
        : base(NAME, WEIGHT)
    {
    }
}