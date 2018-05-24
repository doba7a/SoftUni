using System;
using System.Linq;

public class Engine
{
    private IKingdom kingdom;

    public void Run()
    {
        CreateKingdom();

        string input = Console.ReadLine();

        while (input != "End")
        {
            if (input == "Attack King")
            {
                this.kingdom.King.RespondToAttack();
            }
            else
            {
                string guardName = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

                this.kingdom.AttackGuard(guardName);
            }

            input = Console.ReadLine();
        }
    }

    private void CreateKingdom()
    {
        string kingsName = Console.ReadLine();
        King king = new King(kingsName);

        this.kingdom = new Kingdom(king);

        IKingGuard[] royalGuards = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(royalGuardName => new RoyalGuard(royalGuardName))
            .ToArray();
        this.kingdom.AddGuards(royalGuards);

        IKingGuard[] footmen = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(footmanName => new Footman(footmanName))
            .ToArray();
        this.kingdom.AddGuards(footmen);
    }
}

