public abstract class Mission : IMission
{
    private string name;
    private double scoreToComplete;

    protected Mission(string name, double scoreToComplete)
    {
        this.Name = name;
        this.ScoreToComplete = scoreToComplete;
    }

    public string Name { get => name; protected set => name = value; }

    public double ScoreToComplete { get => scoreToComplete; protected set => scoreToComplete = value; }

    public abstract double EnduranceRequired { get; }

    public abstract double WearLevelDecrement { get; }
}

