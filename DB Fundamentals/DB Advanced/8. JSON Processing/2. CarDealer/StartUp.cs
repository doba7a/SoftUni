namespace CarDealer
{
    using Newtonsoft.Json;
    using CarDealer.Data;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Import Tasks
            //AddSuppliers(context);
            //AddParts(context);
            //AddCars(context);
            //AddCustomers(context);
            //AddSales(context);

            //Query And Export Tasks
            //OrderedCustomers(context);
            //CarsFromMakeToyota(context);
            //LocalSuppliers(context);
            //CarsWithTheirListOfParts(context);
            //TotalSalesByCustomer(context);
            //SalesWithAppliedDiscount(context);
        }

        private static void AddSuppliers(CarDealerContext context)
        {
            string jsonAsString = File.ReadAllText("../../../JSONFiles/suppliers.json");

            Supplier[] deserializedSuppliers = JsonConvert.DeserializeObject<Supplier[]>(jsonAsString);

            context.Suppliers.AddRange(deserializedSuppliers);
            context.SaveChanges();
        }

        private static void AddParts(CarDealerContext context)
        {
            Random rnd = new Random();

            string jsonAsString = File.ReadAllText("../../../JSONFiles/parts.json");

            Part[] deserializedParts = JsonConvert.DeserializeObject<Part[]>(jsonAsString);

            foreach (Part part in deserializedParts)
            {
                int supplierId = rnd.Next(1, 32);
                Supplier supplier = context.Suppliers.Find(supplierId);

                part.SupplierId = supplierId;
                part.Supplier = supplier;
            }

            context.Parts.AddRange(deserializedParts);
            context.SaveChanges();
        }

        private static void AddCars(CarDealerContext context)
        {
            Random rnd = new Random();
            int carId = 1;

            string jsonAsString = File.ReadAllText("../../../JSONFiles/cars.json");

            Car[] deserializedCars = JsonConvert.DeserializeObject<Car[]>(jsonAsString);

            foreach (Car car in deserializedCars)
            {
                int partsCount = rnd.Next(10, 21);

                List<int> partsIds = new List<int>();

                for (int i = 0; i < partsCount; i++)
                {
                    int partId = rnd.Next(1, 132);

                    if (partsIds.Contains(partId))
                    {
                        i--;
                        continue;
                    }

                    Part part = context.Parts.Find(partId);
                    partsIds.Add(partId);

                    PartCar pc = new PartCar()
                    {
                        CarId = carId,
                        Car = car,
                        PartId = partId,
                        Part = part
                    };

                    car.PartCars.Add(pc);
                }

                carId++;
            }

            context.Cars.AddRange(deserializedCars);
            context.SaveChanges();
        }

        private static void AddCustomers(CarDealerContext context)
        {
            string jsonAsString = File.ReadAllText("../../../JSONFiles/customers.json");

            Customer[] deserializedCustomers = JsonConvert.DeserializeObject<Customer[]>(jsonAsString);

            context.Customers.AddRange(deserializedCustomers);
            context.SaveChanges();
        }

        private static void AddSales(CarDealerContext context)
        {
            Random rnd = new Random();

            List<int> soldCarsIds = new List<int>();
            List<Sale> sales = new List<Sale>();
            Dictionary<int, int> discounts = new Dictionary<int, int>()
            {
                { 1 , 0 },
                { 2 , 5 },
                { 3 , 10 },
                { 4 , 15 },
                { 5 , 20 },
                { 6 , 30 },
                { 7 , 40 },
                { 8 , 50 }
            };

            for (int i = 0; i < 200; i++)
            {
                int carId = rnd.Next(1, 359);

                if (soldCarsIds.Contains(carId))
                {
                    i--;
                    continue;
                }

                Car car = context.Cars.Find(carId);

                int customerId = rnd.Next(1, 31);
                Customer customer = context.Customers.Find(customerId);

                int youngDriverDiscount = context.Customers.Find(customerId).IsYoungDriver ? 5 : 0;

                int discountId = rnd.Next(1, 9);

                int totalDiscount = discounts[discountId] + youngDriverDiscount;

                Sale sale = new Sale()
                {
                    CarId = carId,
                    Car = car,
                    CustomerId = customerId,
                    Customer = customer,
                    Discount = totalDiscount
                };

                sales.Add(sale);
                soldCarsIds.Add(carId);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver,
                    Sales = c.Sales.Select(s => new
                    {
                        CarMake = s.Car.Make,
                        CarModel = s.Car.Model,
                        Discount = s.Discount
                    })
                })
                .ToArray();

            string jsonCustmers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/ordered-customers.json", jsonCustmers);
        }

        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            string jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/cars-from-make-toyota.json", jsonCars);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            string jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/local-suppliers.json", jsonSuppliers);
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        pc.Part.Name,
                        pc.Part.Price
                    })
                    .ToArray()
                })
                .ToArray();

            string jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/cars-with-their-list-of-parts.json", jsonCars);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            string jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/total-sales-by-customer.json", jsonCustomers);
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount / 100,
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100)))
                })
                .ToArray();

            string jsonSales = JsonConvert.SerializeObject(sales, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/sales-with-applied-discount.json", jsonSales);
        }
    }
}
