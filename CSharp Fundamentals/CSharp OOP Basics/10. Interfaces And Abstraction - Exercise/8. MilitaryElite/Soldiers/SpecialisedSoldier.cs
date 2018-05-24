using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps)
        :base(id, firstName, lastName, salary)
    {
        this.Corps = Enum.Parse<Corps>(corps);
    }

    public Corps Corps { get; private set; }
}

