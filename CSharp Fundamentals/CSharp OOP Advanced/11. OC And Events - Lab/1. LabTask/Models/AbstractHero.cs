using System;

public abstract class AbstractHero : IAttacker, IObserver
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    private IHandler combatLogger;

    public AbstractHero(string id, int damage, IHandler combatLogger)
    {
        this.id = id;
        this.damage = damage;
        this.combatLogger = combatLogger;
    }

    public void Attack()
    {
        if (this.target == null)
        {
            this.combatLogger.Handle(LogType.ATTACK, String.Format(NO_TARGET_MESSAGE, this));
        }
        else if (this.target.IsDead)
        {
            this.combatLogger.Handle(LogType.ATTACK, String.Format(TARGET_DEAD_MESSAGE, this.target));
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if (target == null)
        {
            this.combatLogger.Handle(LogType.TARGET, TARGET_NULL_MESSAGE);
        }
        else
        {
            this.target = target;

            this.combatLogger.Handle(LogType.TARGET, String.Format(SET_TARGET_MESSAGE, this, target));
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    public void Update(int value)
    {
        this.combatLogger.Handle(LogType.EVENT, "Update");
    }

    public override string ToString()
    {
        return this.id;
    }
}
