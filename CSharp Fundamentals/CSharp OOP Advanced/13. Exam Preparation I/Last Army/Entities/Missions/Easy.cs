public class Easy : Mission
{
    private const string NAME = "Suppression of civil rebellion";
    private const double ENDURANCE_REQUIRED = 20;
    private const double WEAR_LEVEL_DECREMENT = 30;

    public Easy(double scoreToComplete) 
        : base(NAME, scoreToComplete)
    {
    }

    public override double EnduranceRequired => ENDURANCE_REQUIRED;

    public override double WearLevelDecrement => WEAR_LEVEL_DECREMENT;
}

