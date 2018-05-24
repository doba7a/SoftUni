using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicles
{
    private const double IncreaseFuelConsumption = 1.6;
    private const double DecreeseFuelQuantity = 0.95;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption + IncreaseFuelConsumption, tankCapacity)
    {

    }

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (fuel + this.FuelQuantity * DecreeseFuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }

        this.FuelQuantity += (fuel * DecreeseFuelQuantity);
    }
}

