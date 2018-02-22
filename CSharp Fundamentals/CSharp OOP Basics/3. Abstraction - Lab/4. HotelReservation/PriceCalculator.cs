using System.Collections.Generic;

public class PriceCalculator
{
    public static double CalculatePrice(double pricePerDay, int days, string season, string discountType)
    {

        Dictionary<string, int> Season = new Dictionary<string, int>()
        {
            { "Autumn" , 1 }, { "Spring" , 2 }, { "Winter" , 3 }, { "Summer" , 4 }
        };

        Dictionary<string, int> DiscountType = new Dictionary<string, int>()
        {
            { "VIP" , 20 }, { "SecondVisit" , 10 }, { "None" , 0 }
        };

        int seasonMultiplier = Season[season];
        double discount = DiscountType[discountType];

        double price = (pricePerDay * days * seasonMultiplier) * (1.00 - discount / 100);

        return price;
    }
}
