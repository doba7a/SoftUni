using System;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string modelGiven, Engine engineGiven, Cargo cargoGiven, Tire[] tiresGiven)
    {
        this.Model = modelGiven;
        this.Engine = engineGiven;
        this.Cargo = cargoGiven;
        this.Tires = tiresGiven;
    }

    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public Cargo Cargo { get => cargo; set => cargo = value; }
    public Tire[] Tires { get => tires; set => tires = value; }
}

