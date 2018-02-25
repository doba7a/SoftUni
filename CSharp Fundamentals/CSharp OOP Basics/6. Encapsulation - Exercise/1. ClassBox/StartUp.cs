using System;

public class StartUp
{
    public static void Main()
    {
        double boxLength = double.Parse(Console.ReadLine());
        double boxWidth = double.Parse(Console.ReadLine());
        double boxHeight = double.Parse(Console.ReadLine());

        Box box = new Box(boxLength, boxWidth, boxHeight);

        Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {box.Volume():F2}");
    }
}

