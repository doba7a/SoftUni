using System;

public class GemFactory : IGemFactory
{
    public IGem CreateGem(Clarity gemClarity, string kindOfGem)
    {
        Type classType = Type.GetType(kindOfGem);

        IGem currentGem = (IGem)Activator.CreateInstance(classType, new object[] { gemClarity });

        return currentGem;
    }
}

