using System;

public class Car
{
    private string model;
    private Engine engine;
    private string weigth;
    private string color;

    public Car(string modelGiven, Engine engineGiven)
    {
        this.Model = modelGiven;
        this.Engine = engineGiven;
        this.Weigth = "n/a";
        this.Color = "n/a";
    }

    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public string Weigth { get => weigth; set => weigth = value; }
    public string Color { get => color; set => color = value; }

    public override string ToString()
    {
        return $"{this.Model}:{Environment.NewLine}  {Engine.ToString()}{Environment.NewLine}  Weight: {this.Weigth}{Environment.NewLine}  Color: {this.Color}";
    }
}

