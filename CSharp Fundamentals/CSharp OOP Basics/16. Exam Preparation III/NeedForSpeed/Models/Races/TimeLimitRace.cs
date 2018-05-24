using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get => goldTime; private set => goldTime = value; }

    public void TryAddParticipant(Car participant)
    {
        if (this.Participants.Count == 0)
        {
            this.Participants.Add(participant);
        }
    }

    public override string GetRaceWinners()
    {
        Car participant = this.Participants.First();
        int participantTimePerfomance = this.Length * ((participant.Horsepower / 100) * participant.Acceleration);
        string participantEarnedTime = this.GetEarnedTime(participantTimePerfomance);
        double prize = GetPrize(participantEarnedTime);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}")
            .AppendLine($"{participant.Brand} {participant.Model} - {participantTimePerfomance} s.")
            .AppendLine($"{participantEarnedTime} Time, ${(int)prize}.");

        return sb.ToString().Trim();
    }

    private string GetEarnedTime(int participantTimePerfomance)
    {
        if (participantTimePerfomance <= this.GoldTime)
        {
            return "Gold";
        }
        else if (participantTimePerfomance <= this.GoldTime + 15)
        {
            return "Silver";
        }
        else
        {
            return "Bronze";
        }
    }

    private double GetPrize(string participantEarnedTime)
    {
        if (participantEarnedTime == "Gold")
        {
            return this.PrizePool;
        }
        else if (participantEarnedTime == "Silver")
        {
            return this.PrizePool * 0.5;
        }
        else
        {
            return this.PrizePool * 0.3;
        }
    }
}

