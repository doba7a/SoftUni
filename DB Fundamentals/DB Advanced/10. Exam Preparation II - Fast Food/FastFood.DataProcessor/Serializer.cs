using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            OrderType orderTypeAsEnum = Enum.Parse<OrderType>(orderType);

            var ordersByEmployee = context.Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new
                {
                    Name = e.Name,
                    Orders = e.Orders.Where(o => o.Type == orderTypeAsEnum)
                        .OrderByDescending(o => o.TotalPrice)
                        .ThenByDescending(o => o.OrderItems.Sum(i => i.Quantity))
                        .Select(o => new
                    {
                        Customer = o.Customer,
                        Items = o.OrderItems.Select(i => new
                        {
                            Name = i.Item.Name,
                            Price = i.Item.Price,
                            Quantity = i.Quantity
                        })
                        .ToArray(),
                        TotalPrice = o.TotalPrice
                    })
                    .ToArray(),
                    TotalMade = e.Orders.Where(s => s.Type == orderTypeAsEnum).Sum(o => o.TotalPrice)
                })
                .First();

            string jsonPosts = JsonConvert.SerializeObject(ordersByEmployee, Newtonsoft.Json.Formatting.Indented);

            return jsonPosts;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var categoryNamesAsArray = categoriesString.Split(',');

            ExpCategoryDto[] expCategories = new ExpCategoryDto[categoryNamesAsArray.Length];

            for (int i = 0; i < categoryNamesAsArray.Length; i++)
            {
                string category = categoryNamesAsArray[i];

                ExpCategoryDto expCategory = context.Categories
                    .Where(c => c.Name == category)
                    .Select(c => new ExpCategoryDto
                    {
                        Name = c.Name,
                        MostPopularItem = c.Items
                        .Select(it => new ExpItemDto
                        {
                            Name = it.Name,
                            TotalMade = it.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity),
                            TimesSold = it.OrderItems.Sum(oi => oi.Quantity)
                        })
                        .OrderByDescending(it => it.TotalMade)
                        .ThenByDescending(it => it.TimesSold)
                        .First()
                    })
                    .First();

                expCategories[i] = expCategory;
            }

            expCategories = expCategories
                .OrderByDescending(c => c.MostPopularItem.TotalMade)
                .ThenByDescending(c => c.MostPopularItem.TimesSold)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            XmlSerializer serializer = new XmlSerializer(typeof(ExpCategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), expCategories, xmlSerializerNamespaces);

            return sb.ToString().TrimEnd();
        }
	}
}