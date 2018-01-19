namespace PizzaIngredients
{
    using System;
    using System.Linq;

    public class PizzaIngredients
    {
        public static void Main()
        {
            string[] arrayOfAllIngredients = Console.ReadLine().Split(' ').ToArray();
            int searchedIngredientLength = int.Parse(Console.ReadLine());

            string[] arrayOfUsedIngredients = arrayOfAllIngredients
                .Where(x => x.Length == searchedIngredientLength)
                .Take(10)
                .ToArray();

            PrintResult(arrayOfUsedIngredients);
        }

        public static void PrintResult(string[] arrayOfUsedIngredients)
        {
            foreach (string ingredient in arrayOfUsedIngredients)
            {
                Console.WriteLine($"Adding {ingredient}.");
            }
            Console.WriteLine($"Made pizza with total of {arrayOfUsedIngredients.Length} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", arrayOfUsedIngredients)}.");
        }
    }
}