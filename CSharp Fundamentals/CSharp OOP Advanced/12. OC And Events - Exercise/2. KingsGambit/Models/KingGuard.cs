public abstract class KingGuard : IKingGuard
{
    private string name;
    private int health;

    public KingGuard(string name, int health)
    {
        this.Name = name;
        this.Health = health;
    }

    public string Name { get => name; private set => name = value; }
    public int Health { get => health; private set => health = value; }

    public void AttackGuard()
    {
        this.Health -= 1;
    }

    public abstract void NoLongerRespondToAttack(King king);

    public abstract void RespondToAttack(King king);
}

