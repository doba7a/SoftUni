using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicles
{
    private double fuelQuantity;

    public Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double TankCapacity { get; set; }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (value > this.TankCapacity)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    } 
    
    public double FuelConsumption { get; set; }

    public string Drive(double distance, double increaseFuelConsumption)
    {
        double fuelConsum = (this.FuelConsumption + increaseFuelConsumption) * distance;

        if (this.FuelQuantity > fuelConsum)
        {
            this.FuelQuantity -= fuelConsum;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (fuel + this.FuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }

        this.FuelQuantity += fuel;
    }

}

