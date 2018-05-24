using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string[] lightSignalsAsStrings = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<TrafficLight> lightSignals = new List<TrafficLight>();

        for (int i = 0; i < lightSignalsAsStrings.Length; i++)
        {
            lightSignals.Add(new TrafficLight(lightSignalsAsStrings[i]));
        }

        int nTimesToChangeLightSignals = int.Parse(Console.ReadLine());

        for (int i = 0; i < nTimesToChangeLightSignals; i++)
        {
            lightSignals.ForEach(l => l.ChangeLight());

            Console.WriteLine(string.Join(" ", lightSignals));
        }
    }
}

