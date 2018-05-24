public class TargetCommand : ICommand
{
    private IAttacker hero;
    private ITarget dragon;

    public TargetCommand(IAttacker hero, ITarget dragon)
    {
        this.hero = hero;
        this.dragon = dragon;
    }

    public void Execute()
    {
        this.hero.SetTarget(dragon);
        this.hero.Attack();
    }
}
