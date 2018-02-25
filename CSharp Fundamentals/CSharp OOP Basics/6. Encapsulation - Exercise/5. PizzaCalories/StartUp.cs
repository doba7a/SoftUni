using System;

public class StartUp
{
    private static Pizza pizza;

    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string pizzaName = input.Split()[1];

        try
        {
            pizza = new Pizza(pizzaName);

            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                GetData(tokens);

                input = Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }

        Console.WriteLine(pizza);
    }

    private static void GetData(string[] tokens)
    {
        string inputType = tokens[0];

        if (inputType == "Dough")
        {
            GetDough(tokens);
        }
        else if (inputType == "Topping")
        {
            GetTopping(tokens);
        }
    }

    private static void GetTopping(string[] tokens)
    {
        string toppingType = tokens[1];
        double weight = double.Parse(tokens[2]);

        Topping topping = new Topping(toppingType, weight);
        pizza.AddToppings(topping);
    }

    private static void GetDough(string[] tokens)
    {
        string flourType = tokens[1];
        string technique = tokens[2];
        double weight = double.Parse(tokens[3]);

        Dough dough = new Dough(flourType, technique, weight);
        pizza.Dough = dough;
    }
}