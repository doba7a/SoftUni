public class AttackCommand : ICommand
{
    private IAttacker abstractHero;

    public AttackCommand(IAttacker hero)
    {
        this.abstractHero = hero;
    }

    public void Execute()
    {
        this.abstractHero.Attack();
    }
}
