public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";
    private IHandler combatLogger;

    public Warrior(string id, int damage, IHandler combatLogger)
        : base(id, damage, combatLogger)
    {
        this.combatLogger = combatLogger;
    }

    protected override void ExecuteClassSpecificAttack(ITarget target, int damage)
    {

        this.combatLogger.Handle(LogType.ATTACK, "Successful");
    }
}
