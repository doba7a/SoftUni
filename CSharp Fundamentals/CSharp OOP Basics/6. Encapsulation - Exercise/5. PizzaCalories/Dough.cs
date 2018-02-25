using System;

public class Dough
{
    private const double whiteFlour = 1.5;
    private const double wholegrainFlour = 1;
    private const double crispy = 0.9;
    private const double chewy = 1.1;
    private const double homemade = 1;

    private string flourType;
    private string backingTechnique;
    private double weight;

    public Dough(string flourType, string backingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BackingTechnique = backingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get { return flourType; }
        set
        {
            string type = value.ToLower();

            if (type != "white" && type != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    private string BackingTechnique
    {
        get { return backingTechnique; }
        set
        {
            string tech = value.ToLower();

            if (tech != "crispy" && tech != "chewy" && tech != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            backingTechnique = value;
        }
    }

    private double Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
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
        double backing = GetBackingTechnique();
        double flour = GetFlourType();
        double result = (2 * this.Weight) * backing * flour;
        return result;
    }

    private double GetFlourType()
    {
        if (this.FlourType.ToLower() == "white")
        {
            return whiteFlour;
        }
        return wholegrainFlour;
    }

    private double GetBackingTechnique()
    {
        string technique = this.BackingTechnique.ToLower();

        if (technique == "crispy")
        {
            return crispy;
        }
        else if (technique == "chewy")
        {
            return chewy;
        }
        return homemade;
    }
}