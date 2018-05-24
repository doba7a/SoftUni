public interface IKillable
{
    int Health { get; }

    void RespondToAttack(King king);

    void NoLongerRespondToAttack(King king);

    void AttackGuard();
}

