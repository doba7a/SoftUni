namespace CakeIngredients
{
    using System;

    public class CakeIngredients
    {
        public static void Main()
        {
            var currentIngredient = Console.ReadLine();
            var ingredientsCount = 0;

            while (currentIngredient != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {currentIngredient}.");

                ingredientsCount++;

                currentIngredient = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {ingredientsCount} ingredients.");
        }
    }
}