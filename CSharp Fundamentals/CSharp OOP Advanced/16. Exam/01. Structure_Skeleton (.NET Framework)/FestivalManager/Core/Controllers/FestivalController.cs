namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string SetRegistered = "Registered {0} set";
        private const string PerformerRegistered = "Registered performer {0}";
        private const string SongRegistered = "Registered song {0}";
        private const string InvalidSet = "Invalid set provided";
        private const string InvalidSong = "Invalid song provided";
        private const string InvalidPerformer = "Invalid performer provided";
        private const string SongAdded = "Added {0} to {1}";
        private const string PerformerAdded = "Added {0} to {1}";
        private const string InstrumentsRepaired = "Repaired {0} instruments";
        private const string FestivaLength = "Festival length: {0:D2}:{1:D2}";

        private const int SongHours = 0;

        private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;
        private IPerformerFactory performerFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
            this.performerFactory = new PerformerFactory();
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformer);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            ISet set = this.stage.GetSet(setName);
            IPerformer performer = this.stage.GetPerformer(performerName);

            set.AddPerformer(performer);

            return string.Format(PerformerAdded, performerName, setName);
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSet);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(InvalidSong);
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(SongAdded, song.ToString(), setName);
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            int minutes = totalFestivalLength.Minutes + totalFestivalLength.Hours * 60;
            int seconds = totalFestivalLength.Seconds;

            sb.AppendLine(string.Format(FestivaLength, minutes, seconds));

            foreach (ISet set in this.stage.Sets)
            {
                sb.AppendLine(set.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(SetRegistered, type);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];

            string durationAsString = args[1];
            int minutes = int.Parse(durationAsString.Split(':')[0]);
            int seconds = int.Parse(durationAsString.Split(':')[1]);

            TimeSpan songDuration = new TimeSpan(SongHours, minutes, seconds);

            ISong song = this.songFactory.CreateSong(name, songDuration);
            this.stage.AddSong(song);

            return string.Format(SongRegistered, song.ToString());
        }

        public string RepairInstruments(string[] args)
        {
            IInstrument[] instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (IInstrument instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return string.Format(InstrumentsRepaired, instrumentsToRepair.Length);
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            string[] instrumentTypes = args.Skip(2).ToArray();
            foreach (string instrumentType in instrumentTypes)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentType);
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(PerformerRegistered, name);
        }

    }
}