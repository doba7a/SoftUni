using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type ammunitionType = assembly.GetTypes().FirstOrDefault(t => t.Name == ammunitionName);

        if (ammunitionType == null)
        {
            throw new InvalidOperationException("Ammunition not found!");
        }

        if (!typeof(IAmmunition).IsAssignableFrom(ammunitionType))
        {
            throw new InvalidOperationException($"{ammunitionType} is not an ammunition!");
        }

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammunitionType);

        return ammunition;
    }
}
