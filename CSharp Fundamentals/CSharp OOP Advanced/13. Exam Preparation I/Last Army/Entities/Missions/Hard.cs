public class Hard : Mission
{
    private const string NAME = "Disposal of terrorists";
    private const double ENDURANCE_REQUIRED = 80;
    private const double WEAR_LEVEL_DECREMENT = 70;

    public Hard(double scoreToComplete)
        : base(NAME, scoreToComplete)
    {
    }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => WEAR_LEVEL_DECREMENT;
}
