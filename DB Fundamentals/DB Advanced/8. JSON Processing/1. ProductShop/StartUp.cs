namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Import Tasks
            //AddUsers(context);
            //AddCategories(context);
            //AddProducts(context);
            //AddCategoryProducts(context);

            //Query And Export Tasks
            //ProductsInRange(context);
            //SuccessfullySoldProducts(context);
            //CategoriesByProductsCount(context);
            //UsersAndProducts(context);
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }

        private static void AddUsers(ProductShopContext context)
        {
            string jsonAsString = File.ReadAllText("../../../JSONFiles/users.json");

            User[] deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonAsString);
            List<User> validUsers = new List<User>();

            foreach (User user in deserializedUsers)
            {
                if (!IsValid(user))
                {
                    continue;
                }

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();
        }

        private static void AddCategories(ProductShopContext context)
        {
            string jsonAsString = File.ReadAllText("../../../JSONFiles/categories.json");

            Category[] deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonAsString);
            List<Category> validCategories = new List<Category>();

            foreach (Category category in deserializedCategories)
            {
                if (!IsValid(category))
                {
                    continue;
                }

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();
        }

        private static void AddProducts(ProductShopContext context)
        {
            Random rnd = new Random();
            int nullCounter = 1;

            string jsonAsString = File.ReadAllText("../../../JSONFiles/products.json");

            Product[] deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonAsString);
            List<Product> validProducts = new List<Product>();

            foreach (Product product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                int sellerId = rnd.Next(1, 30);
                int buyerId = rnd.Next(31, 57);

                product.SellerId = sellerId;
                product.BuyerId = buyerId;

                if (nullCounter == 4)
                {
                    product.BuyerId = null;
                }

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
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
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName ?? p.Seller.LastName
                })
                .ToArray();

            string jsonProducts = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/products-in-range.json", jsonProducts);
        }

        private static void SuccessfullySoldProducts(ProductShopContext context)
        {
            var successfullySoldProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1 && u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(ps => ps.BuyerId != null).Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName
                    })
                    .ToArray()
                })
                .ToArray();

            string jsonProducts = JsonConvert.SerializeObject(successfullySoldProducts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            File.WriteAllText("../../../JSONFiles/successfully-sold-products.json", jsonProducts);
        }

        private static void CategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Select(cp => cp.Product.Price).DefaultIfEmpty(0).Average(),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .ToArray();

            string jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/categories-by-products-count.json", jsonCategories);
        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(x => new
                {
                    usersCount = context.Users.Where(u => u.ProductsSold.Count >= 1).Count(),
                    users = context.Users.Where(u => u.ProductsSold.Count >= 1).Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count,
                            products = u.ProductsSold.Select(ps => new
                            {
                                name = ps.Name,
                                price = ps.Price
                            })
                        }
                    })
                });

            string jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);

            File.WriteAllText("../../../JSONFiles/users-and-products.json", jsonUsers);
        }
    }
}
