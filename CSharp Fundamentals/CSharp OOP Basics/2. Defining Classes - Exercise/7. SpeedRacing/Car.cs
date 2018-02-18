using System;

class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumptionPerKm;
    private int distanceTraveled;

    public Car(string modelGiven, decimal fuelAmountGiven, decimal fuelConsumptionGiven)
    {
        this.Model = modelGiven;
        this.FuelAmount = fuelAmountGiven;
        this.FuelConsumptionPerKm = fuelConsumptionGiven;
        this.DistanceTraveled = 0;
    }

    public string Model { get => model; set => model = value; }
    public decimal FuelAmount { get => fuelAmount; set => fuelAmount = value; }
    public decimal FuelConsumptionPerKm { get => fuelConsumptionPerKm; set => fuelConsumptionPerKm = value; }
    public int DistanceTraveled { get => distanceTraveled; set => distanceTraveled = value; }

    public static void DriveCar(Car carGiven, int driveDistance)
    {
        if (carGiven.FuelAmount >= driveDistance * carGiven.FuelConsumptionPerKm)
        {
            carGiven.DistanceTraveled += driveDistance;

            carGiven.FuelAmount -= driveDistance * carGiven.FuelConsumptionPerKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}

