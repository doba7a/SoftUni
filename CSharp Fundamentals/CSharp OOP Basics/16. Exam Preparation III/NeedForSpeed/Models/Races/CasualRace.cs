using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool)
        :base(length, route, prizePool)
    {
    }

    public override string GetRaceWinners()
    {
        List<Car> winners = this.Participants.OrderByDescending(c => c.GetOverallPerfomance()).Take(3).ToList();

        StringBuilder sb = new StringBuilder();
        int count = 1;

        sb.AppendLine($"{this.Route} - {this.Length}");
        foreach (Car car in winners)
        {
            sb.AppendLine($"{count++}. {car.Brand} {car.Model} {car.GetOverallPerfomance()}PP - ${this.CalculatePrize(count - 1)}");
        }

        return sb.ToString().Trim();
    }
}

