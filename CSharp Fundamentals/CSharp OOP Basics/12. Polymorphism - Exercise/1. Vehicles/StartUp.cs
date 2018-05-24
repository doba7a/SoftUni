using System;

public class StartUp
{
    private static Car car;
    private static Truck truck;

    public static void Main(string[] args)
    {
        string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] truckData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        car = GetCar(carData);
        truck = GetTruck(truckData);

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

            string message = string.Empty;

            switch (type)
            {
                case "Car":
                    DoAction(car, command, amount);   
                    break;
                case "Truck":
                    DoAction(truck, command, amount);
                    break;
            }        
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }

    private static void DoAction(Vehicles vehicle, string command, double amount)
    {
        string message = string.Empty;

        switch (command)
        {
            case "Drive":
                message = vehicle.Drive(amount);
                Console.WriteLine(message);
                break;
            case "Refuel":
                vehicle.Refuel(amount);
                break;
        }
    }

    private static Truck GetTruck(string[] truckData)
    {
        double truckFuelQuantity = double.Parse(truckData[1]);
        double truckFuelConsumption = double.Parse(truckData[2]);

        return new Truck(truckFuelQuantity, truckFuelConsumption);
    }

    private static Car GetCar(string[] carData)
    {
        double carFuelQuantity = double.Parse(carData[1]);
        double carFuelConsumption = double.Parse(carData[2]);

        return new Car(carFuelQuantity, carFuelConsumption);
    }
}

