namespace TheaThePhotographer
{
    using System;

    public class TheaThePhotographer
    {
        public static void Main()
        {
            ulong picturesTaken = ulong.Parse(Console.ReadLine());
            ulong filterTime = ulong.Parse(Console.ReadLine());
            ulong filterFactor = ulong.Parse(Console.ReadLine());
            ulong uploadTime = ulong.Parse(Console.ReadLine());

            ulong picturesLeft = (ulong)Math.Ceiling(picturesTaken * (filterFactor / 100.0));
            ulong totalTime = picturesTaken * filterTime + picturesLeft * uploadTime;

            TimeSpan Time = TimeSpan.FromSeconds(totalTime);

            string answer = string.Format("{0}:{1:D2}:{2:D2}:{3:D2}", Time.Days, Time.Hours, Time.Minutes, Time.Seconds);
            Console.WriteLine(answer);
        }
    }
}