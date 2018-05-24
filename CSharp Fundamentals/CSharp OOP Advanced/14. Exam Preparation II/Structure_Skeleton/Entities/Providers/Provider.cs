using System;

public abstract class Provider : IProvider
{
    private double energyOutput;
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = Constants.InitialDurability;
    }

    public double EnergyOutput { get => energyOutput; protected set => energyOutput = value; }

    public int ID { get; }

    public double Durability
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
        this.Durability -= Constants.DurabilityLoss;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}