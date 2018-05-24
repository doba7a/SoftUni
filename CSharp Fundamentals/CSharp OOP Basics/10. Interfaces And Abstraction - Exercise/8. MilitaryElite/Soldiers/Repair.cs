using System;
using System.Collections.Generic;
using System.Text;

public class Repair : IRepair
{
    public Repair(string repairPart, int repairHours)
    {
        this.RepairPart = repairPart;
        this.RepairHours = repairHours;
    }

    public string RepairPart { get; private set; }

    public int RepairHours { get; private set; }

    public override string ToString()
    {
        return $"Part Name: {RepairPart} Hours Worked: {RepairHours}";
    }
}

