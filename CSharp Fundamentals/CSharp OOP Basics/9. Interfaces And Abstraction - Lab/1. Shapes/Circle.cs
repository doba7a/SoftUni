using System;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.Radius = radius;
    }

    public int Radius { get => radius; private set => radius = value; }

    public void Draw()
    {
        double innerRadius = this.Radius - 0.4;
        double outterRadius = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; y--)
        {
            for (double x = -this.Radius; x < outterRadius; x += 0.5)
            {
                double value = x * x + y * y;

                if (value <= outterRadius * outterRadius && value >= innerRadius * innerRadius)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}
