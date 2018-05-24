using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    protected string name;
    protected string favouriteFood;

    public Animal(string name, string food)
    {
        this.name = name;
        this.favouriteFood = food;
    }

    public virtual string ExplainMyself()
    {
        return string.Empty;
    }
}


