using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        Car[] carsData = new Car[numberOfInputs];

        for (int i = 0; i < numberOfInputs; i++)
        {
            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = inputData[0];
            decimal fuelAmount = decimal.Parse(inputData[1]);
            decimal fuelConsumption = decimal.Parse(inputData[2]);

            Car currentCar = new Car(model, fuelAmount, fuelConsumption);

            carsData[i] = currentCar;
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string modelToDrive = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
            int distanceToDrive = int.Parse(command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[2]);

            Car.DriveCar(carsData.Where(c => c.Model == modelToDrive).FirstOrDefault(), distanceToDrive);

            command = Console.ReadLine();
        }

        foreach (Car car in carsData)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
        }
    }
}

