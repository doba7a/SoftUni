﻿using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string providerResult = this.providerController.Produce();
        string harvesterResult = this.harvesterController.Produce();

        return providerResult + Environment.NewLine + harvesterResult;
    }
}

