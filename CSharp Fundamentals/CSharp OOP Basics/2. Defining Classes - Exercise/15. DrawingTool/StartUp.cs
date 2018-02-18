using System;

public class StartUp
{
    public static void Main()
    {
        string figure = Console.ReadLine();

        switch (figure)
        {
            case "Square":
                int size = int.Parse(Console.ReadLine());

                Square square = new Square(size);

                square.Draw();

                break;
            case "Rectangle":
                int sizeA = int.Parse(Console.ReadLine());
                int sizeB = int.Parse(Console.ReadLine());

                Rectangle rectangle = new Rectangle(sizeA, sizeB);

                rectangle.Draw();

                break;
        }
    }
}

