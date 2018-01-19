namespace SalesReport
{
    using System;
    using System.Collections.Generic;

    public class SalesReport
    {
        public static void Main()
        {
            int numberOfSales = int.Parse(Console.ReadLine());

            SortedDictionary<string, decimal> salesByTown = new SortedDictionary<string, decimal>();

            for (int i = 0; i < numberOfSales; i++)
            {
                Sale currentSale = Sale.ReadSale(Console.ReadLine());

                if (!salesByTown.ContainsKey(currentSale.Town))
                {
                    salesByTown[currentSale.Town] = 0;
                }

                salesByTown[currentSale.Town] += currentSale.Price * currentSale.Quantity;
            }

            foreach (var town in salesByTown)
            {
                Console.WriteLine($"{town.Key} -> {town.Value:F2}");
            }
        }
    }

    public class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public static Sale ReadSale(string saleData)
        {
            string[] currentSaleData = saleData.Split(' ');

            string currentSaleTown = currentSaleData[0];
            string currentSaleProduct = currentSaleData[1];
            decimal currentSalePrice = decimal.Parse(currentSaleData[2]);
            decimal currentSaleQuantity = decimal.Parse(currentSaleData[3]);

            Sale currentSale = new Sale
            {
                Town = currentSaleTown,
                Product = currentSaleProduct,
                Price = currentSalePrice,
                Quantity = currentSaleQuantity
            };

            return currentSale;
        }
    }
}