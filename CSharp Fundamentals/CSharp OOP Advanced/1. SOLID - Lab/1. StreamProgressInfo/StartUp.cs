using System;

public class StartUp
{
    public static void Main()
    {
        IStreamable file = new File("newFile", 100, 1000);
        StreamProgressInfo fileSPI = new StreamProgressInfo(file);
        Console.WriteLine(fileSPI.CalculateCurrentPercent());

        IStreamable music = new Music("Goshp", "OtPochivka", 123, 4221);
        StreamProgressInfo musicSPI = new StreamProgressInfo(music);
        Console.WriteLine(musicSPI.CalculateCurrentPercent());

        IStreamable video = new Video("YouTube", 500, 5);
        StreamProgressInfo videoSPI = new StreamProgressInfo(video);
        Console.WriteLine(videoSPI.CalculateCurrentPercent());
    }
}

