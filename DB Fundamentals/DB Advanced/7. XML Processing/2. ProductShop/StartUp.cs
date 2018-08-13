namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dto.ExportDto;
    using ProductShop.Dto.ImportDto;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using DataAnnotations = System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main()
        {
            IMapper mapper = InitializeAutomapper();
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Import Tasks
            //AddUsers(mapper, context);
            //AddCategories(mapper, context);
            //AddProducts(mapper, context);
            //AddCategoryProducts(context);

            //Query And Export Tasks
            //ProductsInRange(context);
            //UsersSoldProducts(context);
            //CategoriesByProductsCount(context);
            //UsersAndProducts(context);
        }

        private static IMapper InitializeAutomapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }

        private static void AddUsers(IMapper mapper, ProductShopContext context)
        {
            string xmlAsString = File.ReadAllText("../../../XMLFiles/users.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Dto.ImportDto.UserDto[]), new XmlRootAttribute("users"));

            Dto.ImportDto.UserDto[] deserializedUsers = (Dto.ImportDto.UserDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<User> users = new List<User>();

            foreach (Dto.ImportDto.UserDto userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                User user = mapper.Map<User>(userDto);

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void AddCategories(IMapper mapper, ProductShopContext context)
        {
            string xmlAsString = File.ReadAllText("../../../XMLFiles/categories.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));

            CategoryDto[] deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Category> categories = new List<Category>();

            foreach (CategoryDto categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void AddProducts(IMapper mapper, ProductShopContext context)
        {
            string xmlAsString = File.ReadAllText("../../../XMLFiles/products.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Dto.ImportDto.ProductDto[]), new XmlRootAttribute("products"));

            Dto.ImportDto.ProductDto[] deserializedProducts = (Dto.ImportDto.ProductDto[])serializer.Deserialize(new StringReader(xmlAsString));

            List<Product> products = new List<Product>();
            int nullCounter = 1;

            foreach (Dto.ImportDto.ProductDto productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                Product product = mapper.Map<Product>(productDto);

                int sellerId = new Random().Next(1, 57);
                int buyerId = new Random().Next(1, 57);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                if (nullCounter == 5)
                {
                    product.BuyerId = null;
                    nullCounter = 0;
                }

                products.Add(product);
                nullCounter++;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void AddCategoryProducts(ProductShopContext context)
        {
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                int categoryId = new Random().Next(1, 12);

                CategoryProduct cp = new CategoryProduct()
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };

                categoryProducts.Add(cp);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            ProductInRangeDto[] products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                .OrderByDescending(p => p.Price)
                .Select(x => new ProductInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName ?? x.Buyer.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/products-in-range.xml", sb.ToString());
        }

        private static void UsersSoldProducts(ProductShopContext context)
        {
            UserSoldProductDto[] usersSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(x => new UserSoldProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(y => new SoldProductDto
                    {
                        Name = y.Name,
                        Price = y.Price
                    })
                    .ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(UserSoldProductDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), usersSoldProducts, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/users-sold-products.xml", sb.ToString());
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            CategoryByProductsDto[] categoriesByProducts = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new CategoryByProductsDto
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(c => c.Product.Price).DefaultIfEmpty(0).Average(),
                    TotalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .ToArray();
            
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryByProductsDto[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categoriesByProducts, xmlSerializerNamespaces);
            
            File.WriteAllText("../../../XMLFiles/categories-by-products.xml", sb.ToString());
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            Dto.ExportDto.UserDto[] users = context.Users.Where(x => x.ProductsSold.Any(a => a.BuyerId != null))
                               .Select(x => new Dto.ExportDto.UserDto
                               {
                                   FirstName = x.FirstName,
                                   LastName = x.LastName,
                                   Age = x.Age.ToString(),
                                   Products = new ProductsDto
                                   {
                                       Count = x.ProductsSold.Where(b => b.BuyerId != null).Count(),
                                       Product = x.ProductsSold.Where(b => b.BuyerId != null)
                                                    .Select(a => new Dto.ExportDto.ProductDto
                                                    {
                                                        Name = a.Name,
                                                        Price = a.Price
                                                    })
                                                    .ToArray()
                                   }
                               })
                               .OrderByDescending(x => x.Products.Count)
                               .ToArray();

            Dto.ExportDto.UsersDto usersDto = new UsersDto { Count = users.Count(), Users = users };

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), usersDto, xmlSerializerNamespaces);

            File.WriteAllText("../../../XMLFiles/users-and-products.xml", sb.ToString());
        }
    }
}
