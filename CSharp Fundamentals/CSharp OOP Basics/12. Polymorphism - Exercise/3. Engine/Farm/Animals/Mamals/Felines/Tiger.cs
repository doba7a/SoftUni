using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    public const double IncreaseWeight = 1.00;

    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
        : base(name, weight, foodEaten, livingRegion, breed)
    {
    }

    public override void CanEat(string food, int quantity)
    {
        Console.WriteLine("ROAR!!!");

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

