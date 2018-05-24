using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<IMission>();
    }

    public ICollection<IMission> Missions { get; set; }

    public void AddRepair(IMission mission)
    {
        Missions.Add(mission);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine($"Corps: {Corps}");
        sb.AppendLine("Missions:");
        sb.AppendLine($"{String.Join("\n", Missions)}");
        return sb.ToString().TrimEnd();
    }
}

