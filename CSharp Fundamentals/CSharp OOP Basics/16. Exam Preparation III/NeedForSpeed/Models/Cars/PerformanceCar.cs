using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        :base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += this.Horsepower / 2;
        this.Suspension -= this.Suspension / 4;
    }

    public List<string> AddOns { get => addOns; private set => addOns = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(base.ToString())
            .Append("Add-ons: ");

        if (this.AddOns.Count > 0)
        {
            sb.Append(string.Join(", ", this.AddOns));
        }
        else
        {
            sb.Append("None");
        }

        return sb.ToString();
    }
}

