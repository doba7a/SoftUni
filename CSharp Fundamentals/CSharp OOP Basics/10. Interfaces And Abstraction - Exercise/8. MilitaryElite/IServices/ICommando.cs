using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando : ISpecialisedSoldier
{ 
    ICollection<IMission> Missions { get; }

    void AddRepair(IMission mission);
}

