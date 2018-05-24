using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicles
{
    private const double IncreaseFuelConsumption = 1.6;
    private const double DecreeseFuelQuantity = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption + IncreaseFuelConsumption)
    {

    }

    public override void Refuel(double fuel)
    {
        this.FuelQuantity += (fuel * DecreeseFuelQuantity);
    }
}

