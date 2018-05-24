using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;
    private List<IHarvester> harvesters;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
        this.harvesters = new List<IHarvester>();
        this.mode = Constants.DefaultMode;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        string result = string.Format(Constants.ModeChange, mode);

        return result;
    }

    public string Produce()
    {
        double energyNeeded = this.harvesters.Sum(h => h.EnergyRequirement);
        if (this.mode == "Half")
        {
            energyNeeded *= Constants.HalfModeValue;
        }
        else if (this.mode == "Energy")
        {
            energyNeeded *= Constants.EnergyModeValue;
        }

        double oreOutputToday = 0;
        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            oreOutputToday = this.harvesters.Sum(h => h.OreOutput);
            if (this.mode == "Half")
            {
                oreOutputToday *= Constants.HalfModeValue;
            }
            else if (this.mode == "Energy")
            {
                oreOutputToday *= Constants.EnergyModeValue;
            }
        }

        this.OreProduced += oreOutputToday;

        string result = string.Format(Constants.OreOutputToday, oreOutputToday);

        return result;
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}

