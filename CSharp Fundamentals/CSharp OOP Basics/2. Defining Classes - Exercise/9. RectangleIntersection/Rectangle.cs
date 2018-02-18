using System;

public class Rectangle
{
    private string id;
    private int width;
    private int height;
    private double[] topLeftCoordinates;

    public Rectangle(string idGiven, int widthGiven, int heightGiven, double[] topLeftCoordinatesGiven)
    {
        this.Id = idGiven;
        this.Width = widthGiven;
        this.Height = heightGiven;
        this.TopLeftCoordinates = topLeftCoordinatesGiven;
    }

    public string Id { get => id; set => id = value; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }
    public double[] TopLeftCoordinates { get => topLeftCoordinates; set => topLeftCoordinates = value; }

    public static bool Intersect(Rectangle firstRectangle, Rectangle secondRectangle)
    {
        return !(firstRectangle.topLeftCoordinates[0] > secondRectangle.topLeftCoordinates[0] + secondRectangle.Width) &&
                !(firstRectangle.topLeftCoordinates[0] + firstRectangle.Width < secondRectangle.topLeftCoordinates[0]) &&
                !(firstRectangle.topLeftCoordinates[1] > secondRectangle.topLeftCoordinates[1] + secondRectangle.Height) &&
                !(firstRectangle.topLeftCoordinates[1] + firstRectangle.Height < secondRectangle.topLeftCoordinates[1]);

    }
}

