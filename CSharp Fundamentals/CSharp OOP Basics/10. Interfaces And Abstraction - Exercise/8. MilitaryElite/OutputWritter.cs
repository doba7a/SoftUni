using System;
using System.Collections.Generic;
using System.Text;

public static class OutputWritter
{
    public static void Print(List<ISoldier> soldiers)
    {
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

}

