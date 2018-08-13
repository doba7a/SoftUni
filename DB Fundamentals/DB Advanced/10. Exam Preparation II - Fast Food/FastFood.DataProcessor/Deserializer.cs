using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            ImpEmployeeDto[] deserializedEmployees = JsonConvert.DeserializeObject<ImpEmployeeDto[]>(jsonString);
            List<Employee> validEmployees = new List<Employee>();

            foreach (ImpEmployeeDto empDto in deserializedEmployees)
            {
                if (!IsValid(empDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = context.Positions.SingleOrDefault(p => p.Name == empDto.Position);
                if (position == null)
                {
                    position = new Position()
                    {
                        Name = empDto.Position
                    };

                    context.Positions.Add(position);
                    context.SaveChanges();
                }

                Employee emp = new Employee()
                {
                    Name = empDto.Name,
                    Age = empDto.Age,
                    Position = position
                };

                validEmployees.Add(emp);
                sb.AppendLine(string.Format(SuccessMessage, emp.Name));
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            ImpItemDto[] deserializedItems = JsonConvert.DeserializeObject<ImpItemDto[]>(jsonString);
            List<Item> validItems = new List<Item>();

            foreach (ImpItemDto itemDto in deserializedItems)
            {
                if (!IsValid(itemDto) || validItems.Any(i => i.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = context.Categories.SingleOrDefault(c => c.Name == itemDto.Category);
                if (category == null)
                {
                    category = new Category()
                    {
                        Name = itemDto.Category
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();
                }

                Item item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };

                validItems.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(validItems);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImpOrderDto[]), new XmlRootAttribute("Orders"));

            ImpOrderDto[] deserializedOrders = (ImpOrderDto[])serializer.Deserialize(new StringReader(xmlString));
            List<Order> validOrders = new List<Order>();
            List<OrderItem> validOrderItems = new List<OrderItem>();

            foreach (ImpOrderDto orderDto in deserializedOrders)
            {
                Employee emp = context.Employees.SingleOrDefault(e => e.Name == orderDto.Employee);

                if (!IsValid(orderDto)
                    || emp == null
                    || !orderDto.Items.Any(IsValid)
                    || !orderDto.Items.All(i => context.Items.Select(ii => ii.Name).Contains(i.Name)))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime dateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                OrderType type = Enum.Parse<OrderType>(orderDto.Type);

                Order order = new Order()
                {
                    Customer = orderDto.Customer,
                    Employee = emp,
                    DateTime = dateTime,
                    Type = type
                };

                validOrders.Add(order);

                foreach (ImpOrderItemDto impOrderItemDto in orderDto.Items)
                {
                    Item item = context.Items.FirstOrDefault(x => x.Name == impOrderItemDto.Name);

                    OrderItem orderItem = new OrderItem
                    {
                        Order = order,
                        Item = item,
                        Quantity = impOrderItemDto.Quantity
                    };

                    validOrderItems.Add(orderItem);
                }

                sb.AppendLine($"Order for {orderDto.Customer} on {orderDto.DateTime} added");
            }

            context.Orders.AddRange(validOrders);
            context.SaveChanges();

            context.OrderItems.AddRange(validOrderItems);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}