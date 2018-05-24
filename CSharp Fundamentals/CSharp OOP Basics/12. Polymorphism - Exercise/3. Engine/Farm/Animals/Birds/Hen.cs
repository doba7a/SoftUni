using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public const double IncreaseWeight = 0.35;

    public Hen(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, foodEaten, wingSize)
    {
    }

    public override void CanEat(string food, int quantity)
    {
        this.FoodEeaten += quantity;
        this.Weight += IncreaseWeight * quantity;
        Console.WriteLine($"Cluck");
    }
}

