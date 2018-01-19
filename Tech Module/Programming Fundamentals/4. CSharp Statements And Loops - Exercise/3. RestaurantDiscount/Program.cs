namespace RestaurantDiscount
{
    using System;

    public class RestaurantDiscount
    {
        public static void Main()
        {
            var groupSize = int.Parse(Console.ReadLine());
            var packageType = Console.ReadLine();

            double hallPrice = 0;
            string hallType = String.Empty;

            if (groupSize > 0 && groupSize <= 50)
            {
                hallPrice = 2500;
                hallType = "Small Hall";
            }
            else if (groupSize <= 100)
            {
                hallPrice = 5000;
                hallType = "Terrace";
            }
            else if (groupSize <= 120)
            {
                hallPrice = 7500;
                hallType = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                Environment.Exit(1);
            }

            double packagePrice = 0;
            double packageDiscount = 0;

            if (packageType == "Normal")
            {
                packagePrice = 500;
                packageDiscount = 0.05;
            }
            else if (packageType == "Gold")
            {
                packagePrice = 750;
                packageDiscount = 0.10;
            }
            else if (packageType == "Platinum")
            {
                packagePrice = 1000;
                packageDiscount = 0.15;
            }

            var totalPrice = hallPrice + packagePrice;
            var pricePerPerson = ((totalPrice - (totalPrice * packageDiscount))) / groupSize;

            Console.WriteLine($"We can offer you the {hallType}\r\nThe price per person is {pricePerPerson:F2}$");
        }
    }
}