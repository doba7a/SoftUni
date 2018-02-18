using System;

public class Car
{
    private string model;
    private int speed;

    public Car(string modelGiven, int speedGiven)
    {
        this.Model = modelGiven;
        this.speed = speedGiven;
    }

    public string Model { get => model; set => model = value; }
    public int Speed { get => speed; set => speed = value; }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}{Environment.NewLine}";
    }
}

