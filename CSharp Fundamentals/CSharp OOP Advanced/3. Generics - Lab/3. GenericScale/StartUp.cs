using System;

public class StartUp
{
    public static void Main()
    {
        IScale<int> scale = new Scale<int>(33, 44);

        Console.WriteLine(scale.GetHeavier());
    }
}

