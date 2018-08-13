﻿namespace P03_FootballBetting.Data.Models
{
    using P03_FootballBetting.Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public GameResult Result { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public int BetId { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}