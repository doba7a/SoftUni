using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    public const double IncreaseWeight = 0.40;

    public Dog(string name, double weight, int foodEaten, string livingRegion)
        : base(name, weight, foodEaten, livingRegion)
    {
    }

    public override void CanEat(string food, int quantity)
    {
        Console.WriteLine("Woof!");

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

