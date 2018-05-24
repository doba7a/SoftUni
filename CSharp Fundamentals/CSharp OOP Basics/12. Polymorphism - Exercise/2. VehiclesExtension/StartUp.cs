using System;

public class StartUp
{
    private static Car car;
    private static Truck truck;
    private static Bus bus;
    private static double fuelQuantity;
    private static double fuelConsumption;
    private static double tankCapacity;

    public static void Main(string[] args)
    {
        string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] truckData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] busData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        car = GetCar(carData);
        truck = GetTruck(truckData);
        bus = GetBus(busData);

        ReadCommands();
    }

    private static void ReadCommands()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = input[0];
            string type = input[1];
            double amount = double.Parse(input[2]);
            try
            {
                switch (type)
                {
                    case "Car":
                        DoAction(car, command, amount);
                        break;
                    case "Truck":
                        DoAction(truck, command, amount);
                        break;
                    case "Bus":
                        DoAction(bus, command, amount);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
    }

    private static void DoAction(Vehicles vehicle, string command, double amount)
    {
        string message = string.Empty;
        double increaseFuelCon = 0;

        if (vehicle is Bus)
        {
            increaseFuelCon = 1.4;
        }
     
        switch (command)
        {
            case "Drive":
                message = vehicle.Drive(amount, increaseFuelCon);
                Console.WriteLine(message);
                break;
            case "DriveEmpty":
                message = vehicle.Drive(amount, 0);
                Console.WriteLine(message);
                break;
            case "Refuel":
                vehicle.Refuel(amount);
                break;
        }
    }

    private static Bus GetBus(string[] busData)
    {
        fuelQuantity = double.Parse(busData[1]);
        fuelConsumption = double.Parse(busData[2]);
        tankCapacity = double.Parse(busData[3]);

        return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
    }

    private static Truck GetTruck(string[] truckData)
    {
        fuelQuantity = double.Parse(truckData[1]);
        fuelConsumption = double.Parse(truckData[2]);
        tankCapacity = double.Parse(truckData[3]);

        return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
    }

    private static Car GetCar(string[] carData)
    {
        fuelQuantity = double.Parse(carData[1]);
        fuelConsumption = double.Parse(carData[2]);
        tankCapacity = double.Parse(carData[3]);

        return new Car(fuelQuantity, fuelConsumption, tankCapacity);
    }
}

