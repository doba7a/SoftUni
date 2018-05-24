namespace FestivalManager.Entities.Sets
{
    using FestivalManager.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Set : ISet
    {
        private const string SongOverLimit = "Song is over the set limit!";
        private const string SetMainInfo = "--{0} ({1}):";
        private const string NoSongsInSet = "--No songs played";
        private const string SongsPlayed = "--Songs played:";

        private string name;
        private TimeSpan maxDuration;
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;

        protected Set(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.maxDuration = maxDuration;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get => name; private set => name = value; }

        public TimeSpan MaxDuration { get => maxDuration; private set => maxDuration = value; }

        public TimeSpan ActualDuration => new TimeSpan(this.songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            TimeSpan newActualDuration = this.ActualDuration + song.Duration;
            if (newActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException(SongOverLimit);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            bool performersAvailable = this.performers.Count > 0;
            bool songsAvailable = this.songs.Count > 0;
            bool instrumentsForUsage = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (performersAvailable && songsAvailable && instrumentsForUsage)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            int minutes = this.ActualDuration.Minutes + this.ActualDuration.Hours * 60;
            int seconds = this.ActualDuration.Seconds;

            string setDuration = $"{minutes:D2}:{seconds:D2}";
            sb.AppendLine(string.Format(SetMainInfo, this.Name, setDuration));

            foreach (IPerformer performer in this.Performers.OrderByDescending(p => p.Age))
            {
                sb.AppendLine($"---{performer.ToString()}");
            }

            if (this.Songs.Count == 0)
            {
                sb.AppendLine(NoSongsInSet);
            }
            else
            {
                sb.AppendLine(SongsPlayed);
            }

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"----{song.ToString()}");
            }

            var result = sb.ToString().Trim();
            return result;
        }
    }
}
