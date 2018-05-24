﻿using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle : Shape
{ 
    public double Height { get; private set; }
    public double Width { get; private set; }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public override double CalculateArea()
    {
        return Height * Width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Height + Width);
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

