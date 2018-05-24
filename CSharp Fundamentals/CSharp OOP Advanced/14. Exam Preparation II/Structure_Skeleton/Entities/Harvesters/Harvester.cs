using System;

public abstract class Harvester : IHarvester
{
    private double oreOutput;
    private double energyRequirement;
    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = Constants.InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get => oreOutput; protected set => oreOutput = value; }

    public double EnergyRequirement { get => energyRequirement; protected set => energyRequirement = value; }

    public virtual double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            if (value <= 0)
            {
                throw new Exception();
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.durability -= Constants.DurabilityLoss;
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}