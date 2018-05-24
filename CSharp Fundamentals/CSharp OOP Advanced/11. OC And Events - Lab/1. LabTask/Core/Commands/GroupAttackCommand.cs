public class GroupAttackCommand : ICommand
{
    private IAttackGroup attacker;

    public GroupAttackCommand(IAttackGroup attacker)
    {
        this.attacker = attacker;
    }

    public void Execute()
    {
        this.attacker.GroupAttack();
    }
}

