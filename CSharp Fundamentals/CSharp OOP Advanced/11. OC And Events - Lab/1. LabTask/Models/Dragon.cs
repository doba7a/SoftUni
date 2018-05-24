using System;

public class Dragon : IObservableTarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler combatLogger;

    public Dragon(string id, int hp, int reward, IHandler combatLogger)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.combatLogger = combatLogger;
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if (this.IsDead && !eventTriggered)
        {
            this.combatLogger.Handle(LogType.TARGET, String.Format(THIS_DIED_EVENT, this));
            this.eventTriggered = true;
        }
    }

    public void Update(int value)
    {
        this.combatLogger.Handle(LogType.EVENT, "Update");
    }

    public override string ToString()
    {
        return this.id;
    }
}
