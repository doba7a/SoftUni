public class Rectangle
{
    private Point bottomLeft;
    private Point topRight;

    public Rectangle(Point bottomLeft, Point topRight)
    {
        this.bottomLeft = bottomLeft;
        this.topRight = topRight;
    }

    public bool ContainsPoint(Point point)
    {
        return point.X >= bottomLeft.X && point.X <= topRight.X
            && point.Y >= bottomLeft.Y && point.Y <= topRight.Y;
    }
}