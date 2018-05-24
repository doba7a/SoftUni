using System.Collections.Generic;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length { get => length; private set => length = value; }
    public string Route { get => route; private set => route = value; }
    public int PrizePool { get => prizePool; private set => prizePool = value; }
    public List<Car> Participants { get => participants; private set => participants = value; }

    public abstract string GetRaceWinners();

    protected double CalculatePrize(int place)
    {
        if (place == 1)
        {
            return this.PrizePool * 0.5;
        }
        else if (place == 2)
        {
            return this.PrizePool * 0.3;
        }
        else
        {
            return this.PrizePool * 0.2;
        }
    }
}

