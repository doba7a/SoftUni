using System.Collections.Generic;

public interface IKingdom
{
    King King { get; }

    List<IKingGuard> KingGuards { get; }

    void AddGuards(IEnumerable<IKingGuard> guards);

    void AttackGuard(string guardName);
}

