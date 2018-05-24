using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> carsData;
    private Dictionary<int, Race> racesData;
    private Garage garage;
    private Dictionary<int, List<int>> carsCurrentlyRacing;

    public CarManager()
    {
        this.carsData = new Dictionary<int, Car>();
        this.racesData = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.carsCurrentlyRacing = new Dictionary<int, List<int>>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (this.carsData.ContainsKey(id) || this.garage.ParkedCars.ContainsKey(id))
        {
            return;
        }

        if (type == "Performance")
        {
            this.carsData[id] = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
        else if (type == "Show")
        {
            this.carsData[id] = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
    }

    public string Check(int id)
    {
        if (this.carsData.ContainsKey(id))
        {
            return this.carsData[id].ToString();
        }
        else
        {
            return this.garage.ParkedCars[id].ToString();
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int secondaryParam)
    {
        if (this.racesData.ContainsKey(id))
        {
            return;
        }

        if (type == "Casual")
        {
            this.racesData[id] = new CasualRace(length, route, prizePool);
        }
        else if (type == "Drag")
        {
            this.racesData[id] = new DragRace(length, route, prizePool);
        }
        else if (type == "Drift")
        {
            this.racesData[id] = new DriftRace(length, route, prizePool);
        }
        else if (type == "TimeLimit")
        {
            this.racesData[id] = new TimeLimitRace(length, route, prizePool, secondaryParam);
        }
        else if (type == "Circuit")
        {
            this.racesData[id] = new CircuitRace(length, route, prizePool, secondaryParam);
        }

        this.carsCurrentlyRacing[id] = new List<int>();
    }

    public void Participate(int carId, int raceId)
    {
        if (this.garage.ParkedCars.ContainsKey(carId) || !this.racesData.ContainsKey(raceId))
        {
            return;
        }

        if (racesData[raceId] is TimeLimitRace timeLimitRace)
        {
            timeLimitRace.TryAddParticipant(carsData[carId]);
        }
        else
        {
            this.racesData[raceId].Participants.Add(this.carsData[carId]);
        }

        this.carsCurrentlyRacing[raceId].Add(carId);
    }

    public string Start(int id)
    {
        if (this.racesData[id].Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        string output = this.racesData[id].GetRaceWinners();

        this.racesData.Remove(id);
        this.carsCurrentlyRacing.Remove(id);

        return output;
    }

    public void Park(int id)
    {
        if (this.carsCurrentlyRacing.Values.Any(c => c.Any(i => i == id)))
        {
            return;
        }

        this.garage.ParkedCars[id] = this.carsData[id];
        this.carsData.Remove(id);
    }

    public void Unpark(int id)
    {
        this.carsData[id] = this.garage.ParkedCars[id];
        this.garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOnn)
    {
        if (this.garage.ParkedCars.Count == 0)
        {
            return;
        }

        this.garage.ModifyParkedCars(tuneIndex, addOnn);
    }
}

