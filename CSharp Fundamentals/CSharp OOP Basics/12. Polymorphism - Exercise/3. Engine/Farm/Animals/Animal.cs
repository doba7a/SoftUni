using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    public Animal(string name, double weight, int foodEaten)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEeaten = foodEaten;
    }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int FoodEeaten { get; set; }

    public abstract void CanEat(string food, int quantity);

    public string ExceptionMessage => "{0} does not eat {1}!";
}

