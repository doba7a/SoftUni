using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicles
{
    public Vehicles(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; set; } 
    
    public double FuelConsumption { get; set; }

    public string Drive(double distance)
    {
        if (this.FuelQuantity > (this.FuelConsumption * distance))
        {
            this.FuelQuantity -= (this.FuelConsumption * distance);
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }

}

