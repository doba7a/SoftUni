using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static List<Person> persons = new List<Person>();
    private static List<Product> products = new List<Product>();
    private static Person person;
    private static Product product;

    public static void Main()
    {
        string[] inputPerson = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string[] inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        GetPersons(inputPerson);
        GetProducts(inputProducts);

        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] inputData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string personName = inputData[0];
            string productName = inputData[1];

            person = persons.FirstOrDefault(x => x.Name == personName);
            product = products.FirstOrDefault(x => x.Name == productName);

            if (person == null || product == null)
            {
                input = Console.ReadLine();
                continue;
            }

            TryBuyProduct(person, product);

            input = Console.ReadLine();
        }

        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }

    private static void TryBuyProduct(Person person, Product product)
    {
        if (person.Money - product.Cost > 0)
        {
            person.Money -= product.Cost;
            person.BagOfProducts.Add(product);
            Console.WriteLine($"{person.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{person.Name} can't afford {product.Name}");
        }


    }

    private static void GetProducts(string[] inputProducts)
    {
        for (int i = 0; i < inputProducts.Length; i++)
        {
            string[] currentPerson = inputProducts[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = currentPerson[0];
            decimal cost = decimal.Parse(currentPerson[1]);

            try
            {
                products.Add(new Product(name, cost));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }

    private static void GetPersons(string[] inputPerson)
    {
        for (int i = 0; i < inputPerson.Length; i++)
        {
            string[] currentPerson = inputPerson[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            string name = currentPerson[0];
            decimal money = decimal.Parse(currentPerson[1]);

            try
            {
                persons.Add(new Person(name, money));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);

            }
        }
    }
}