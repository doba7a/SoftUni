using System;

public class RoyalGuard : KingGuard
{
    private const int ROYAL_GUARD_HEALTH = 1;

    public RoyalGuard(string name)
        : base(name, ROYAL_GUARD_HEALTH)
    {
    }

    public override void RespondToAttack(King king)
    {
        king.RespondToAttackEventHandler += KingRespondToAttackEventHandler;
    }

    public override void NoLongerRespondToAttack(King king)
    {
        king.RespondToAttackEventHandler -= KingRespondToAttackEventHandler;
    }

    private void KingRespondToAttackEventHandler(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}

