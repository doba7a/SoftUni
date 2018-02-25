using System;
using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    private string name;
    private List<Player> players;

    public FootballTeam(string name)
    {
        this.Name = name;
        Players = new List<Player>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public int Rating
    {
        get { return GetRating(); }
    }

    public List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string name)
    {
        Player player = players.FirstOrDefault(x => x.Name == name);
        Players.Remove(player);
    }

    public int GetRating()
    {
        if (players.Count == 0)
        {
            return 0;
        }

        double sumAverageStat = this.players.Sum(x => x.Stat) / 5;

        return (int)Math.Round(sumAverageStat / this.players.Count);
    }

    public bool IsInTeam(string name)
    {
        if (this.Players.Any(x => x.Name == name))
        {
            return true;
        }

        return false;
    }
}