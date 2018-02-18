using System;
using System.Text;

public class Square : AbstractDraw
{
    private int size;

    public Square(int size)
    {
        this.Size = size;
    }

    public int Size { get => size; set => size = value; }

    public override void Draw()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("|").Append(new string('-', Size)).AppendLine("|");

        for (int i = 0; i < this.Size - 2; i++)
        {
            builder.Append("|").Append(new string(' ', Size)).AppendLine("|");
        }

        if (Size > 1)
        {
            builder.Append("|").Append(new string('-', Size)).AppendLine("|");
        }

        Console.Write(builder.ToString());
    }
}