using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);

        IEntity entity = this.providerController.Entities.FirstOrDefault(e => e.ID == id);

        if (entity != null)
        {
            return string.Format(Constants.EntityToString, entity.GetType().Name, Environment.NewLine, entity.Durability);
        }

        entity = this.harvesterController.Entities.FirstOrDefault(e => e.ID == id);

        if (entity != null)
        {
            return string.Format(Constants.EntityToString, entity.GetType().Name, Environment.NewLine, entity.Durability);
        }

        return string.Format(Constants.NoEntityFound, id);
    }
}

