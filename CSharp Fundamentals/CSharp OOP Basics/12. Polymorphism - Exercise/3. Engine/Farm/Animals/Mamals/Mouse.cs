using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    public const double IncreaseWeight = 0.10;

    public Mouse(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override void CanEat(string food, int quantity)
    {
        Console.WriteLine("Squeak");

        if (food == "Vegetable" || food == "Fruit")
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

