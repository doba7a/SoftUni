using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person()
    {
        this.BagOfProducts = new List<Product>();
    }

    public Person(string name, decimal money)
        : this()
    {
        this.Name = name;
        this.Money = money;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public List<Product> BagOfProducts
    {
        get { return bagOfProducts; }
        set { bagOfProducts = value; }
    }

    public override string ToString()
    {
        string result = (bagOfProducts.Count == 0) ? "Nothing bought" : String.Join(", ", BagOfProducts.Select(x => x.Name));
        return $"{Name} - {result}";
    }
}