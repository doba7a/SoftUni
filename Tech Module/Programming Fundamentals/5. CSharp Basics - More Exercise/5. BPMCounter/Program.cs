namespace BPMCounter
{
    using System;

    public class BPMCounter
    {
        public static void Main()
        {
            var beatsPerMinute = double.Parse(Console.ReadLine());
            var numberOfBeats = double.Parse(Console.ReadLine());

            var bars = numberOfBeats / 4.0;

            var secondsTotal = numberOfBeats / beatsPerMinute * 60.0;

            Console.WriteLine($"{Math.Round(bars, 1)} bars - {Math.Truncate(secondsTotal / 60)}m {Math.Truncate(secondsTotal % 60)}s");
        }
    }
}