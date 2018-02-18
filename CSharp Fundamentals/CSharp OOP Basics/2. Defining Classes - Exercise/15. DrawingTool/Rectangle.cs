using System;
using System.Text;

public class Rectangle : AbstractDraw
{
    private int sizeA;
    private int sizeB;

    public Rectangle(int sizeA, int sizeB)
    {
        this.SizeA = sizeA;
        this.SizeB = sizeB;
    }

    public int SizeA { get => sizeA; set => sizeA = value; }
    public int SizeB { get => sizeB; set => sizeB = value; }

    public override void Draw()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("|").Append(new string('-', SizeA)).AppendLine("|");

        for (int i = 0; i < this.SizeB - 2; i++)
        {
            builder.Append("|").Append(new string(' ', SizeA)).AppendLine("|");
        }

        if (SizeB > 1)
        {
            builder.Append("|").Append(new string('-', SizeA)).AppendLine("|");
        }

        Console.Write(builder.ToString());
    }
}
