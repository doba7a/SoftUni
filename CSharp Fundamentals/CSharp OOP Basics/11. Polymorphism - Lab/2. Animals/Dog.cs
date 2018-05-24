using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Animal
{
    public Dog(string name, string food)
        : base(name, food)
    {

    }

    public override string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}\nDJAAF";
    }
}

