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

            Car currentCar = CreateCar(inputData);

            carsData[i] = currentCar;
        }

        PrintOutput(carsData);
    }

    private static Car CreateCar(string[] inputData)
    {
        string currentModel = inputData[0];

        Engine currentEngine = new Engine(int.Parse(inputData[1]), int.Parse(inputData[2]));

        Cargo currentCargo = new Cargo(int.Parse(inputData[3]), inputData[4]);

        Tire[] currentTires = new Tire[4];

        for (int i = 0; i < 4; i++)
        {
            Tire currentTire = new Tire(double.Parse(inputData[(i * 2) + 5]), int.Parse(inputData[(i * 2) + 6]));

            currentTires[i] = currentTire;
        }

        Car currentCar = new Car(currentModel, currentEngine, currentCargo, currentTires);

        return currentCar;
    }

    private static void PrintOutput(Car[] carsData)
    {
        string fragileOrFlamable = Console.ReadLine();

        if (fragileOrFlamable == "fragile")
        {
            Car[] output = carsData.Where(c => c.Cargo.Type == "fragile").Where(c => c.Tires.Any(t => t.Pressure < 1.0)).ToArray();

            foreach (Car car in output)
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (fragileOrFlamable == "flamable")
        {
            Car[] output = carsData.Where(c => c.Cargo.Type == "flamable").Where(c => c.Engine.Power > 250).ToArray();

            foreach (Car car in output)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

