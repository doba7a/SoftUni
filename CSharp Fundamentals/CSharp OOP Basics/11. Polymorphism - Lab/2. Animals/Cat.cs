using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Animal
{
    public Cat(string name, string food)
        : base(name, food)
    {

    }

    public override string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}\nMEEOW";
    }
}

