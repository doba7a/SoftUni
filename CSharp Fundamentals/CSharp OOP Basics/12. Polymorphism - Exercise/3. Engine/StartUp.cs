using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        Engine engine = new Engine();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] animal = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] food = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string type = animal[0];
            string name = animal[1];
            double weight = double.Parse(animal[2]);

            string nameOfFood = food[0];
            int quantity = int.Parse(food[1]);

            bool isBird = double.TryParse(animal[3], out double size);

            if (animal.Length == 5)
            {
                engine.GetFelines(type, name, weight, animal[3], animal[4], nameOfFood, quantity);
            }
            else if (isBird)
            {
                double wingSize = double.Parse(animal[3]);
                engine.GetBird(type, name, weight, wingSize, nameOfFood, quantity);
            }
            else
            {
                engine.GetMiceDog(type, name, weight, animal[3], nameOfFood, quantity);
            }
        }

        engine.PrintResult();
    }
}

