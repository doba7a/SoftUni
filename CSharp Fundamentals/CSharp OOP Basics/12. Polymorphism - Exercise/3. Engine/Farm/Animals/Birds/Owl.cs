using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    public const double IncreaseWeight = 0.25;

    public Owl(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, foodEaten, wingSize)
    {

    }

    public override void CanEat(string food, int quantity)
    {
        Console.WriteLine("Hoot Hoot");

        if (food == "Meat")
        {
            this.FoodEeaten += quantity;
            this.Weight += IncreaseWeight * quantity;
        }
        else
        {
            string result = String.Format(this.ExceptionMessage, this.GetType().Name, food);
            Console.WriteLine(result);
        }
    }
}

