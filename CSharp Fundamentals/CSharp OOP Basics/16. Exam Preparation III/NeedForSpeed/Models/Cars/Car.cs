using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get => brand; private set => brand = value; }
    public string Model { get => model; private set => model = value; }
    public int YearOfProduction { get => yearOfProduction; private set => yearOfProduction = value; }
    public int Horsepower { get => horsepower; protected set => horsepower = value; }
    public int Acceleration { get => acceleration; private set => acceleration = value; }
    public int Suspension { get => suspension; protected set => suspension = value; }
    public int Durability { get => durability; private set => durability = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }

    public double GetOverallPerfomance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public double GetEnginePerfomance()
    {
        return this.Horsepower / this.Acceleration;
    }

    public double GetSuspensionPerfomance()
    {
        return this.Suspension + this.Durability;
    }

    public void TuneCar(int tuneIndex)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += (int)(tuneIndex * 0.5);
    }

    public void DecreaseDurability(int length)
    {
        this.Durability -= (length * length);
    }
}

