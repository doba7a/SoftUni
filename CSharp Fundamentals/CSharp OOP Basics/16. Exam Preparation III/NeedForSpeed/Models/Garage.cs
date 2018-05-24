using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars { get => parkedCars; set => parkedCars = value; }

    public void ModifyParkedCars(int tuneIndex, string tuneAddOn)
    {
        foreach (Car car in this.ParkedCars.Values)
        {
            car.TuneCar(tuneIndex);

            if (car is PerformanceCar perfomanceCar)
            {
                perfomanceCar.AddOns.Add(tuneAddOn);
            }
            else if (car is ShowCar showCar)
            {
                showCar.IncreaseStars(tuneIndex);
            }
        }
    }
}

