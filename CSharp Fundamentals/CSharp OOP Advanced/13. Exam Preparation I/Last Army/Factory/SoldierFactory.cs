using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type soldierType = assembly.GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        if (soldierType == null)
        {
            throw new InvalidOperationException("Soldier not found!");
        }

        if (!typeof(ISoldier).IsAssignableFrom(soldierType))
        {
            throw new InvalidOperationException($"{soldierType} is not a soldier!");
        }

        object[] args = new object[] { name, age, experience, endurance};

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, args);

        return soldier;
    }
}
