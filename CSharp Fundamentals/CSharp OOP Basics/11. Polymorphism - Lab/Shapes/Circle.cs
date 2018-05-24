using System;
using System.Collections.Generic;
using System.Text;

public class Circle : Shape
{
    public double Width { get; private set; }
    public double Radius { get; private set; }

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}

