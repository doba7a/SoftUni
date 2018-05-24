using System.Text;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
    }

    public int Stars { get => stars; protected set => stars = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(base.ToString())
            .AppendLine($"{this.Stars} *");

        return sb.ToString().Trim();
    }

    public void IncreaseStars(int tuneIndex)
    {
        this.Stars += tuneIndex;
    }
}

