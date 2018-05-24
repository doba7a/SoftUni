using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type classType = Type.GetType(unitType);

        IUnit currentUnit = (IUnit)Activator.CreateInstance(classType);

        return currentUnit;
    }
}

