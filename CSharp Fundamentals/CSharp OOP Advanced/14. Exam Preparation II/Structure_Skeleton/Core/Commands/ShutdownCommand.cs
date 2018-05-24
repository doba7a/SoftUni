using System;
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        return string.Format(Constants.Shutdown, 
            Environment.NewLine, this.providerController.TotalEnergyProduced, Environment.NewLine, this.harvesterController.OreProduced);
    }
}

