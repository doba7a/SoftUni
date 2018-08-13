namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dto.ExportDto;
    using CarDealer.Dto.ImportDto;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            IMapper mapper = InitializeAutomapper();
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Import Tasks
            //AddSuppliers(context, mapper);
            //AddParts(context, mapper);
            //AddCars(context, mapper);
            //AddCustomers(context, mapper);
            //AddSales(context);

            //Query And Export Tasks
            //CarsWithDistance(context);
            //CarsFromMakeFerrari(context);
            //LocalSuppliers(context);
            //CarsWithParts(context);
            //TotalSalesByCustomer(context);
            //SalesWithAppliedDiscount(context);
        }

        private static IMapper InitializeAutomapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        private static void AddSuppliers(CarDealerContext context, IMapper mapper)
        {
            string xmlAsString = File.ReadAllText("../../../XMLFiles/suppliers.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("suppliers"));

            ImportSupplierDto[] deserializedSuppliers = (ImportSupplierDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (ImportSupplierDto supplierDto in deserializedSuppliers)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }

        private static void AddParts(CarDealerContext context, IMapper mapper)
        {
            Random rnd = new Random();

            string xmlAsString = File.ReadAllText("../../../XMLFiles/parts.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("parts"));

            ImportPartDto[] deserializedParts = (ImportPartDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Part> parts = new List<Part>();

            foreach (ImportPartDto partDto in deserializedParts)
            {
                Part part = mapper.Map<Part>(partDto);

                part.SupplierId = rnd.Next(1, 32);

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void AddCars(CarDealerContext context, IMapper mapper)
        {
            Random rnd = new Random();

            string xmlAsString = File.ReadAllText("../../../XMLFiles/cars.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("cars"));

            ImportCarDto[] deserializedCars = (ImportCarDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Car> cars = new List<Car>();
            int carIdCount = 1;

            foreach (ImportCarDto carDto in deserializedCars)
            {
                Car car = mapper.Map<Car>(carDto);

                int carPartsCount = rnd.Next(10, 21);
                List<int> carPartsIds = new List<int>();

                for (int i = 0; i < carPartsCount; i++)
                {
                    int carPartId = rnd.Next(1, 132);

                    if (carPartsIds.Contains(carPartId))
                    {
                        i--;
                        continue;
                    }
                    else
                    {
                        carPartsIds.Add(carPartId);

                        PartCar pc = new PartCar()
                        {
                            CarId = carIdCount,
                            PartId = carPartId
                        };

                        car.PartCars.Add(pc);
                    }
                }

                cars.Add(car);

                carIdCount++;
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void AddCustomers(CarDealerContext context, IMapper mapper)
        {
            Random rnd = new Random();

            string xmlAsString = File.ReadAllText("../../../XMLFiles/customers.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("customers"));

            ImportCustomerDto[] deserializedCustomers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Customer> customers = new List<Customer>();

            foreach (ImportCustomerDto customerDto in deserializedCustomers)
            {
                Customer customer = mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
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

                int customerId = rnd.Next(1, 31);

                int youngDriverDiscount = context.Customers.Find(customerId).IsYoungDriver ? 5 : 0;

                int discountId = rnd.Next(1, 9);

                int totalDiscount = discounts[discountId] + youngDriverDiscount;

                Sale sale = new Sale()
                {
                    CarId = carId,
                    CustomerId = customerId,
                    Discount = totalDiscount
                };

                sales.Add(sale);
                soldCarsIds.Add(carId);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }

        private static void CarsWithDistance(CarDealerContext context)
        {
            ExportCarDto[] carsWithDistance = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carsWithDistance, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/cars-with-distance.xml", sb.ToString());
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            ExportFerrariCarDto[] carsFromMakeFerrari = context.Cars
                .Where(c => c.Make == "Ferrari")
                .Select(c => new ExportFerrariCarDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportFerrariCarDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carsFromMakeFerrari, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/cars-from-make-ferrari.xml", sb.ToString());
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            ExportSupplierDto[] localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSupplierDto[]), new XmlRootAttribute("suppliers"));
            serializer.Serialize(new StringWriter(sb), localSuppliers, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/local-suppliers.xml", sb.ToString());
        }

        private static void CarsWithParts(CarDealerContext context)
        {
            ExportCarWithListOfPartsDto[] carsWithParts = context.Cars
                .Select(c => new ExportCarWithListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    ListOfParts = c.PartCars.Select(cp => new ExportListOfPartsDto
                    {
                        Name = cp.Part.Name,
                        Price = $"{cp.Part.Price:F2}"
                    }).ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarWithListOfPartsDto[]), new XmlRootAttribute("cars"));
            serializer.Serialize(new StringWriter(sb), carsWithParts, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/cars-and-parts.xml", sb.ToString());
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            ExportSalesByCustomerDto[] totalSalesByCustomer = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportSalesByCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSalesByCustomerDto[]), new XmlRootAttribute("customers"));
            serializer.Serialize(new StringWriter(sb), totalSalesByCustomer, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/customers-total-sales.xml", sb.ToString());
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] salesWithDiscount = context.Sales
                .Select(s => new ExportSaleDto
                {
                    Car = new ExportCarWithListOfPartsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount / 100:F2}",
                    Price = $"{s.Car.PartCars.Sum(cp => cp.Part.Price):F2}",
                    PriceWithDiscount = $"{(s.Car.PartCars.Sum(cp => cp.Part.Price) * (1 - (s.Discount / 100))):F2}"
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSaleDto[]), new XmlRootAttribute("sales"));
            serializer.Serialize(new StringWriter(sb), salesWithDiscount, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/sales-discounts.xml", sb.ToString());
        }
    }
}
