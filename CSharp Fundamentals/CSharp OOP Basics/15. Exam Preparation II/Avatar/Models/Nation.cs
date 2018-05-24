using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public List<Bender> Benders { get => benders; private set => benders = value; }
    public List<Monument> Monuments { get => monuments; private set => monuments = value; }

    public double GetNationPower()
    {
        double bendersPower = this.Benders.Sum(b => b.GetBenderPower());
        int monumentsPower = this.Monuments.Sum(m => m.GetMonumentPower());

        double powerIncrease = bendersPower / 100 * monumentsPower;

        return bendersPower + powerIncrease;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append("Benders:");
        if (this.benders.Any())
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.benders.Select(b => $"###{b}")));
        }
        else
        {
            result.AppendLine(" None");
        }

        result.Append("Monuments:");
        if (this.monuments.Any())
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.monuments.Select(m => $"###{m}")));
        }
        else
        {
            result.Append(" None");
        }

        return result.ToString();
    }
}

