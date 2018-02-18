using System;

public class Engine
{
    private string model;
    private int power;
    private string displacement;
    private string efficiency;

    public Engine(string modelGiven, int powerGiven)
    {
        this.Model = modelGiven;
        this.Power = powerGiven;
        this.Displacement = "n/a";
        this.Efficiency = "n/a";
    }

    public string Model { get => model; set => model = value; }
    public int Power { get => power; set => power = value; }
    public string Displacement { get => displacement; set => displacement = value; }
    public string Efficiency { get => efficiency; set => efficiency = value; }

    public override string ToString()
    {
        return $"{this.Model}:{Environment.NewLine}    Power: {this.Power}{Environment.NewLine}    Displacement: {this.Displacement}{Environment.NewLine}    Efficiency: {this.Efficiency}";
    }
}