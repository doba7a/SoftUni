using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());

        Engine[] enginesData = new Engine[numberOfEngines];

        for (int i = 0; i < numberOfEngines; i++)
        {
            enginesData[i] = ReadEngine();
        }

        int numberOfCars = int.Parse(Console.ReadLine());

        Car[] carsData = new Car[numberOfCars];

        for (int i = 0; i < numberOfCars; i++)
        {
            carsData[i] = ReadCar(enginesData);
        }

        foreach (Car car in carsData)
        {
            Console.WriteLine(car);
        }
    }

    private static Car ReadCar(Engine[] enginesData)
    {
        string[] carData = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string carModel = carData[0];
        string engineModel = carData[1];
        Engine carEngine = enginesData.FirstOrDefault(e => e.Model == engineModel);

        Car currentCar = new Car(carModel, carEngine);

        if (carData.Length == 4)
        {
            currentCar.Weigth = carData[2];
            currentCar.Color = carData[3];
        }
        else if (carData.Length == 3)
        {

            if (char.IsLetter(carData[2][0]))
            {
                currentCar.Color = carData[2];
            }
            else
            {
                currentCar.Weigth = carData[2];
            }
        }

        return currentCar;
    }

    private static Engine ReadEngine()
    {
        string[] engineData = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string engineModel = engineData[0];
        int enginePower = int.Parse(engineData[1]);

        Engine currentEngine = new Engine(engineModel, enginePower);

        if (engineData.Length == 4)
        {
            currentEngine.Displacement = engineData[2];
            currentEngine.Efficiency = engineData[3];
        }
        else if (engineData.Length == 3)
        {
            if (char.IsLetter(engineData[2][0]))
            {
                currentEngine.Efficiency = engineData[2];
            }
            else
            {
                currentEngine.Displacement = engineData[2];
            }
        }

        return currentEngine;
    }
}

