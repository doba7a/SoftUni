using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type missionType = assembly.GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);

        if (missionType == null)
        {
            throw new InvalidOperationException("Mission not found!");
        }

        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new InvalidOperationException($"{missionType} is not a mission!");
        }

        object[] args = new object[] { neededPoints };

        IMission mission = (IMission)Activator.CreateInstance(missionType, args);

        return mission;
    }
}

