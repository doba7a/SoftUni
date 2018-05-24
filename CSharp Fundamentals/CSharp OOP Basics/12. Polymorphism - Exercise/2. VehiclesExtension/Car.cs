using System;
using System.Collections.Generic;
using System.Text;

public class Car : Vehicles
{
    private const double IncreaseFuelConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption + IncreaseFuelConsumption, tankCapacity)
    {
   
    }
}

