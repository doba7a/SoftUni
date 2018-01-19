namespace AnonymousDownsite
{
    using System;
    using System.Numerics;

    public class AnonymousDownsite
    {
        public static void Main()
        {
            int numberOfWebsites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLosses = 0;

            for (int i = 0; i < numberOfWebsites; i++)
            {
                string[] currentWebsiteData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string currentWebsiteName = currentWebsiteData[0];
                long currentWebsiteVisits = long.Parse(currentWebsiteData[1]);
                decimal currentWebsitePricePerVisit = decimal.Parse(currentWebsiteData[2]);

                totalLosses += currentWebsiteVisits * currentWebsitePricePerVisit;

                Console.WriteLine(currentWebsiteName);
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, numberOfWebsites);

            Console.WriteLine($"Total Loss: {totalLosses:F20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}