using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 1 || value.Length > 15 || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public void AddToppings(Topping topping)
    {
        if (Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        Toppings.Add(topping);
    }

    private double GetTotalCalories
    {
        get { return toppings.Sum(x => x.TotalCalories) + dough.TotalCalories; }
    }

    public override string ToString()
    {
        return $"{this.Name} - {GetTotalCalories:F2} Calories.";
    }
}
