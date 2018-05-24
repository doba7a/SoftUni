using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get => laps; private set => laps = value; }

    public override string GetRaceWinners()
    {
        int laps = this.Laps;

        for (int i = 0; i < laps; i++)
        {
            foreach (Car participant in this.Participants)
            {
                participant.DecreaseDurability(this.Length);
            }
        }

        List<Car> winners = this.Participants.OrderByDescending(c => c.GetOverallPerfomance()).Take(4).ToList();

        StringBuilder sb = new StringBuilder();
        int count = 1;

        sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");
        foreach (Car car in winners)
        {
            sb.AppendLine($"{count++}. {car.Brand} {car.Model} {car.GetOverallPerfomance()}PP - ${this.CalculateCircuitPrize(count - 1)}");
        }

        return sb.ToString().Trim();
    }

    private double CalculateCircuitPrize(int place)
    {
        if (place == 1)
        {
            return this.PrizePool * 0.4;
        }
        else if (place == 2)
        {
            return this.PrizePool * 0.3;
        }
        else if (place == 3)
        {
            return this.PrizePool * 0.2;
        }
        else
        {
            return this.PrizePool * 0.1;
        }
    }
}

