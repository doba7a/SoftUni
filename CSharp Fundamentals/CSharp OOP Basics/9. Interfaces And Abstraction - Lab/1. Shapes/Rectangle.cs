﻿using System;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get => width; private set => width = value; }
    public int Height { get => height; private set => height = value; }

    public void Draw()
    {
        DrawLine(this.width, '*', '*');

        for (int i = 1; i < this.Height - 1; i++)
        {
            DrawLine(this.width, '*', ' ');
        }

        DrawLine(this.width, '*', '*');
    }

    public void DrawLine(int width, char end, char mid)
    {
        Console.Write(end);

        for (int i = 1; i < width - 1; i++)
        {
            Console.Write(mid);
        }

        Console.WriteLine(end);
    }
}
