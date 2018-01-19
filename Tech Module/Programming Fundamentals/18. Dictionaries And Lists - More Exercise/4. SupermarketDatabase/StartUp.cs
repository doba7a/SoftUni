namespace SupermarketDatabase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SupermarketDatabase
    {
        public static void Main()
        {
            Dictionary<string, int> productsQuantityDictionary = new Dictionary<string, int>();
            Dictionary<string, double> productsPriceDictionary = new Dictionary<string, double>();

            string givenProduct = Console.ReadLine();

            while (givenProduct != "stocked")
            {
                string givenProductName = givenProduct.Split(' ')[0];
                double givenProductPrice = double.Parse(givenProduct.Split(' ')[1]);
                int givenProductQuantity = int.Parse(givenProduct.Split(' ')[2]);

                if (!productsQuantityDictionary.ContainsKey(givenProductName) 
                    && !productsPriceDictionary.ContainsKey(givenProductName))
                {
                    productsPriceDictionary[givenProductName] = 0;
                    productsQuantityDictionary[givenProductName] = 0;            
                }

                productsPriceDictionary[givenProductName] = givenProductPrice;
                productsQuantityDictionary[givenProductName] += givenProductQuantity;

                givenProduct = Console.ReadLine();
            }

            PrintAnswer(productsPriceDictionary, productsQuantityDictionary);
        }

        public static void PrintAnswer(Dictionary<string, double> productsPriceDictionary, Dictionary<string, int> productsQuantityDictionary)
        {
            double grandTotal = 0;

            foreach (var product in productsQuantityDictionary)
            {
                string currentProductName = product.Key;
                double currentProductPrice = productsPriceDictionary[currentProductName];
                int currentProductQuantity = productsQuantityDictionary[currentProductName];
                double currentProductTotal =
                    productsQuantityDictionary[currentProductName] * productsPriceDictionary[currentProductName];

                grandTotal += currentProductTotal;

                Console.WriteLine($"{product.Key}: ${currentProductPrice:F2} * {currentProductQuantity} = ${currentProductTotal:F2}");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }
}