using System.Text;

public class Tesla : Car, IElectricCar
{
    private int battery;

    public Tesla(string model, string color, int battery)
        : base(model, color)
    {
        this.Battery = battery;
    }

    public int Battery { get => battery; private set => battery = value; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{Color} {this.GetType().Name} {Model} with {Battery} Batteries");
        result.AppendLine($"{Start()}");
        result.AppendLine($"{Stop()}");
        return result.ToString().TrimEnd();
    }
}

