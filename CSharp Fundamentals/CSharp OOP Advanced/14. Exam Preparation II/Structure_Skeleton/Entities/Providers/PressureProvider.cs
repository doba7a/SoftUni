﻿public class PressureProvider : Provider
{
    private const double DurabilityLoss = 300;
    private const int EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityLoss;
        this.EnergyOutput *= EnergyOutputMultiplier;
    }
}

