using System;
using System.Collections.Generic;
using System.Text;

public abstract class Food
{
    public Food(int quantity, string foodType)
    {
        this.Quantity = quantity;
        this.Type = Enum.Parse<FoodType>(foodType);
    }

    public int Quantity { get; set; }

    public FoodType Type { get; set; }
}

