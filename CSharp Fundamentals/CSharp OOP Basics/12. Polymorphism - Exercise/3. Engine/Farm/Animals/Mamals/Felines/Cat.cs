using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    public const double IncreaseWeight = 0.30;

    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion, breed)
    {
    }

    public override void CanEat(string food, int quantity)
    {
        Console.WriteLine("Meow");

        if (food == "Vegetable" || food == "Meat")
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

