using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string systemMode;
    private double producedOre;
    private double producedEnergy;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
        this.SystemMode = "Full";
        this.HarvesterFactory = new HarvesterFactory();
        this.ProviderFactory = new ProviderFactory();
    }

    public List<Harvester> Harvesters { get => harvesters; private set => harvesters = value; }
    public List<Provider> Providers { get => providers; private set => providers = value; }
    public string SystemMode { get => systemMode; private set => systemMode = value; }
    public double ProducedOre { get => producedOre; private set => producedOre = value; }
    public double ProducedEnergy { get => producedEnergy; private set => producedEnergy = value; }
    public HarvesterFactory HarvesterFactory { get => harvesterFactory; set => harvesterFactory = value; }
    public ProviderFactory ProviderFactory { get => providerFactory; set => providerFactory = value; }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.Harvesters.Add(this.HarvesterFactory.RegisterHarvester(arguments));
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        string type = arguments[0];
        string id = arguments[1];

        return $"Successfully registered {type} Harvester - {id}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.Providers.Add(this.ProviderFactory.RegisterProvider(arguments));
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

        string type = arguments[0];
        string id = arguments[1];

        return $"Successfully registered {type} Provider - {id}";
    }
    public string Day()
    {
        double energyGatheredToday = this.Providers.Select(pr => pr.EnergyOutput).Sum();
        double neededEnergy = this.Harvesters.Select(h => h.EnergyRequirement).Sum();
        double oresProductivity = this.Harvesters.Select(h => h.OreOutput).Sum();

        this.ProducedEnergy += energyGatheredToday;

        switch (this.SystemMode)
        {
            case "Energy":
                neededEnergy = 0;
                oresProductivity = 0;
                break;
            case "Half":
                neededEnergy *= 0.6;
                oresProductivity *= 0.5;
                break;
        }

        if (this.ProducedEnergy >= neededEnergy)
        {
            this.ProducedEnergy -= neededEnergy;
            this.ProducedOre += oresProductivity;
        }
        else
        {
            oresProductivity = 0;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {energyGatheredToday}")
            .AppendLine($"Plumbus Ore Mined: {oresProductivity}");

        return sb.ToString().Trim();
    }
    public string Mode(List<string> arguments)
    {
        string systemMode = arguments[0];

        this.SystemMode = systemMode;

        return $"Successfully changed working mode to {systemMode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Harvester currentHarvester = this.Harvesters.FirstOrDefault(h => h.Id == id);
        Provider currentProvider = this.Providers.FirstOrDefault(pr => pr.Id == id);

        if (currentHarvester != null)
        {
            string type = currentHarvester.GetType().Name == "HammerHarvester" ? "Hammer" : "Sonic";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{type} Harvester - {id}")
                .AppendLine($"Ore Output: {currentHarvester.OreOutput}")
                .AppendLine($"Energy Requirement: {currentHarvester.EnergyRequirement}");

            return sb.ToString().Trim();
        }
        else if (currentProvider != null)
        {
            string type = currentProvider.GetType().Name == "SolarProvider" ? "Solar" : "Pressure";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{type} Provider - {id}")
                .AppendLine($"Energy Output: {currentProvider.EnergyOutput}");

            return sb.ToString().Trim();
        }

        return $"No element found with id - {id}";
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.ProducedEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.ProducedOre}");

        return sb.ToString().Trim();
    }
}

