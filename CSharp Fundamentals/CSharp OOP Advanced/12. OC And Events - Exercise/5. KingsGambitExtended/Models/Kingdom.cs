using System.Collections.Generic;
using System.Linq;

public class Kingdom : IKingdom
{
    private King king;
    private List<IKingGuard> kingGuards;

    public Kingdom(King king)
    {
        this.KingGuards = new List<IKingGuard>();
        this.King = king;
    }

    public List<IKingGuard> KingGuards { get => kingGuards; set => kingGuards = value; }
    public King King { get => king; private set => king = value; }

    public void AddGuards(IEnumerable<IKingGuard> guards)
    {
        foreach (IKingGuard guard in guards)
        {
            this.KingGuards.Add(guard);
            guard.RespondToAttack(this.King);
        }
    }

    public void AttackGuard(string guardName)
    {
        IKingGuard existingKingGuard = this.KingGuards.First(kg => kg.Name == guardName);

        existingKingGuard.AttackGuard();

        if (existingKingGuard.Health == 0)
        {
            this.KillGuard(existingKingGuard);
        }
    }

    private void KillGuard(IKingGuard existingKingGuard)
    {
        existingKingGuard.NoLongerRespondToAttack(this.King);
        this.KingGuards.Remove(existingKingGuard);
    }
}
