using System;

public class Footman : KingGuard
{
    private const int FOOTMAN_HEALTH = 1;

    public Footman(string name)
        :base(name, FOOTMAN_HEALTH)
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
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

