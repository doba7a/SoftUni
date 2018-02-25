using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private static List<FootballTeam> teamList = new List<FootballTeam>();

    public static void Launch(string[] tokens)
    {
        string command = tokens[0];

        switch (command)
        {
            case "Team":
                TryAddTeam(tokens[1]);
                break;
            case "Add":
                TryAddPlayer(tokens);
                break;
            case "Remove":
                TryRemovePlayer(tokens);
                break;
            case "Rating":
                TryGetRating(tokens[1]);
                break;
        }
    }

    private static void TryGetRating(string teamName)
    {
        FootballTeam footballTeam = teamList.FirstOrDefault(x => x.Name == teamName);

        if (footballTeam == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        Console.WriteLine($"{footballTeam.Name} - {footballTeam.Rating}");
    }

    private static void TryRemovePlayer(string[] tokens)
    {
        string teamName = tokens[1];
        string playerName = tokens[2];

        FootballTeam footballTeam = teamList.FirstOrDefault(x => x.Name == teamName);

        if (!footballTeam.IsInTeam(playerName))
        {
            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
            return;
        }

        footballTeam.RemovePlayer(playerName);
    }

    private static void TryAddPlayer(string[] tokens)
    {
        string teamName = tokens[1];
        FootballTeam footballTeam = teamList.FirstOrDefault(x => x.Name == teamName);

        if (footballTeam == null)
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        string playerName = tokens[2];

        int endurance = int.Parse(tokens[3]);
        int sprint = int.Parse(tokens[4]);
        int dribble = int.Parse(tokens[5]);
        int passing = int.Parse(tokens[6]);
        int shooting = int.Parse(tokens[7]);

        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

        footballTeam.AddPlayer(player);
    }

    private static void TryAddTeam(string teamName)
    {
        FootballTeam footballTeam = new FootballTeam(teamName);
        teamList.Add(footballTeam);
    }
}

