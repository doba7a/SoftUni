using System.Text;


public class Seat : Car
{
    public Seat(string model, string color)
        : base(model, color)
    {

    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"{Color} {GetType().Name} {Model}");
        result.AppendLine($"{Start()}");
        result.AppendLine($"{Stop()}");
        return result.ToString().TrimEnd();
    }
}

