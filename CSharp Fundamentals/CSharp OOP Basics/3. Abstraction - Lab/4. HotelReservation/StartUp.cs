using System;

public class StartUp
{
    public static void Main()
    {
        string[] reservationData = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        double pricePerDay = double.Parse(reservationData[0]);
        int days = int.Parse(reservationData[1]);
        string season = reservationData[2];
        string discountType = "None";

        if (reservationData.Length == 4)
        {
            discountType = reservationData[3];
        }

        double totalPrice = PriceCalculator.CalculatePrice(pricePerDay, days, season, discountType);

        Console.WriteLine($"{totalPrice:F2}");
    }
}

