namespace UpgradedMatcher
{
    using System;
    using System.Linq;

    public class UpgradedMatcher
    {
        public static void Main()
        {
            string[] arrayOfProducts = Console.ReadLine().Split(' ').ToArray();

            long[] arrayOfGivenQuantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long[] arrayOfQuantities = AddMissingQuantities(arrayOfGivenQuantities, arrayOfProducts.Length);

            double[] arrayOfPrices = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            string searchedProductAndQuantity = Console.ReadLine();

            while (searchedProductAndQuantity != "done")
            {
                string searchedProductName = searchedProductAndQuantity.Split(' ')[0];
                int indexOfSearchedProduct = Array.IndexOf(arrayOfProducts, searchedProductName);

                long searchedProductQuantity = long.Parse(searchedProductAndQuantity.Split(' ')[1]);

                if (arrayOfQuantities[indexOfSearchedProduct] >= searchedProductQuantity)
                {
                    double totalPriceOfOrder = searchedProductQuantity * arrayOfPrices[indexOfSearchedProduct];
                    Console.WriteLine($"{searchedProductName} x {searchedProductQuantity} costs {totalPriceOfOrder:F2}");
                    arrayOfQuantities[indexOfSearchedProduct] -= searchedProductQuantity;
                }
                else
                {
                    Console.WriteLine($"We do not have enough {searchedProductName}");
                }

                searchedProductAndQuantity = Console.ReadLine();
            }
        }

        public static long[] AddMissingQuantities(long[] arrayOfGivenQuantities, int neededLength)
        {
            long[] arrayOfQuantities = new long[neededLength];

            if (arrayOfGivenQuantities.Length == neededLength)
            {
                arrayOfQuantities = arrayOfGivenQuantities;
            }
            else
            {
                for (int i = 0; i < arrayOfQuantities.Length; i++)
                {
                    try
                    {
                        arrayOfQuantities[i] = arrayOfGivenQuantities[i];
                    }
                    catch (Exception)
                    {

                        arrayOfQuantities[i] = 0;
                    }
                }
            }

            return arrayOfQuantities;
        }
    }
}