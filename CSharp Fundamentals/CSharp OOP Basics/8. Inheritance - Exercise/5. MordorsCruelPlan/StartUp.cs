using System;

public class StartUp
{
    public static void Main()
    {
        string[] foods = Console.ReadLine()
            .ToLower()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Gandalf gandalf = new Gandalf();

        foreach (var food in foods)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf.HappinessPoints);
        Console.WriteLine(gandalf.CalculateMood());
    }
}