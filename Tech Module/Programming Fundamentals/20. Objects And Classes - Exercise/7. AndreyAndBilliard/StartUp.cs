namespace AndreyAndBilliard
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AndreyAndBilliard
    {
        public static void Main()
        {
            int numberOfProducts = int.Parse(Console.ReadLine());

            Dictionary<string, double> productsDictionary = new Dictionary<string, double>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                string[] currentProductData = Console.ReadLine().Split('-');

                string currentProductName = currentProductData[0];
                double currentProductPrice = double.Parse(currentProductData[1]);

                if (!productsDictionary.ContainsKey(currentProductName))
                {
                    productsDictionary[currentProductName] = 0;
                }

                productsDictionary[currentProductName] = currentProductPrice;
            }

            List<Customer> customersList = new List<Customer>();

            string customerData = Console.ReadLine();

            while (customerData != "end of clients")
            {
                string[] currentCustomerData = customerData.Split('-', ',');

                string currentCustomerName = currentCustomerData[0];
                string currentCustomerProduct = currentCustomerData[1];
                double quantity = double.Parse(currentCustomerData[2]);

                if (!productsDictionary.ContainsKey(currentCustomerProduct))
                {
                    customerData = Console.ReadLine();
                    continue;
                }

                Customer currentCustomer = new Customer();
                currentCustomer.Name = currentCustomerName;
                currentCustomer.ShopList = new Dictionary<string, double>();
                currentCustomer.ShopList.Add(currentCustomerProduct, quantity);

                if (customersList.Any(x => x.Name == currentCustomerName))
                {
                    Customer existingCustomer = customersList.First(x => x.Name == currentCustomerName);
                    if (existingCustomer.ShopList.ContainsKey(currentCustomerProduct))
                    {
                        existingCustomer.ShopList[currentCustomerProduct] += quantity;
                    }
                    else
                    {
                        existingCustomer.ShopList[currentCustomerProduct] = quantity;
                    }
                }
                else
                {
                    customersList.Add(currentCustomer);
                }

                customerData = Console.ReadLine();
            }

            foreach (var customer in customersList)
            {
                foreach (var item in customer.ShopList)
                {
                    foreach (var product in productsDictionary)
                    {
                        if (item.Key == product.Key)
                        {
                            customer.Bill += item.Value * product.Value;
                        }
                    }
                }
            }

            foreach (var customer in customersList.OrderBy(x => x.Name).ThenBy(x => x.Bill))
            {
                Console.WriteLine(customer.Name);
                foreach (var item in customer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:F2}");
            }
            Console.WriteLine($"Total bill: {customersList.Sum(c => c.Bill):F2}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, double> ShopList { get; set; }
        public double Bill { get; set; }
    }
}