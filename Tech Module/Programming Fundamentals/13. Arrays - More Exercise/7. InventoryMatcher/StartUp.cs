namespace InventoryMatcher
{
    using System;
    using System.Linq;

    public class InventoryMatcher
    {
        public static void Main()
        {
            string[] arrayOfProducts = Console.ReadLine().Split(' ').ToArray();
            string[] arrayOfQuantities = Console.ReadLine().Split(' ').ToArray();
            string[] arrayOfPrices = Console.ReadLine().Split(' ').ToArray();

            string searchedProduct = Console.ReadLine();

            while (searchedProduct != "done")
            {
                int indexOfSearchedProduct = Array.IndexOf(arrayOfProducts, searchedProduct);

                Console.WriteLine($"{searchedProduct} costs: {arrayOfPrices[indexOfSearchedProduct]}; Available quantity: {arrayOfQuantities[indexOfSearchedProduct]}");

                searchedProduct = Console.ReadLine();
            }
        }
    }
}