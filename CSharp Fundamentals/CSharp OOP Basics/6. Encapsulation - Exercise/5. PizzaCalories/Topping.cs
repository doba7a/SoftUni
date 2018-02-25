using System;

public class Topping
{
    private const double meat = 1.2;
    private const double veggies = 0.8;
    private const double cheese = 1.1;
    private const double sauce = 0.9;

    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {
        get { return toppingType; }
        set
        {
            string type = value.ToLower();

            if (type != "meat" && type != "veggies" && type != "cheese" && type != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            toppingType = value;
        }
    }

    private double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public double TotalCalories
    {
        get { return GetTotalCalories(); }
    }

    private double GetTotalCalories()
    {
        double topping = GetToppingType();
        double result = (topping * 2) * this.Weight;
        return result;
    }

    private double GetToppingType()
    {
        string type = this.ToppingType.ToLower();

        if (type == "meat")
        {
            return meat;
        }
        else if (type == "veggies")
        {
            return veggies;
        }
        else if (type == "sauce")
        {
            return sauce;
        }
        return cheese;
    }
}
