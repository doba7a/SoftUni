using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(int id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<IRepair>();
    }

    public ICollection<IRepair> Repairs { get; set; }

    //public string RepairPart { get; set; }

    //public int RepairHours { get; set; }

    public void AddRepair(IRepair repair)
    {
        Repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{base.ToString()}");
        sb.AppendLine($"Corps: {Corps}");
        sb.AppendLine("Repairs:");
        sb.AppendLine($"{String.Join("\n", Repairs)}");
        return sb.ToString().TrimEnd();
    }
}

