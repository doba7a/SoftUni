public class Medium : Mission
{
    private const string NAME = "Capturing dangerous criminals";
    private const double ENDURANCE_REQUIRED = 50;
    private const double WEAR_LEVEL_DECREMENT = 50;

    public Medium(double scoreToComplete)
        : base(NAME, scoreToComplete)
    {
    }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => WEAR_LEVEL_DECREMENT;
}

