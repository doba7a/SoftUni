using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        IBuyer[] buyers = AddBuyers();

        string buyerName = Console.ReadLine();

        while (buyerName != "End")
        {
            if (buyers.Any(x => x.Name == buyerName))
            {
                buyers.First(x => x.Name == buyerName).BuyFood();
            }

            buyerName = Console.ReadLine();
        }

        Console.WriteLine(buyers.Sum(x => x.Food));
    }

    public static IBuyer[] AddBuyers()
    {
        int numberOfPotentialBuyers = int.Parse(Console.ReadLine());

        IBuyer[] buyers = new IBuyer[numberOfPotentialBuyers];

        for (int i = 0; i < numberOfPotentialBuyers; i++)
        {
            string[] currentBuyerData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (currentBuyerData.Length == 4)
            {
                IBuyer citizen = new Citizen
                    (currentBuyerData[0], int.Parse(currentBuyerData[1]), currentBuyerData[2], currentBuyerData[3]);

                buyers[i] = citizen;
            }
            else if (currentBuyerData.Length == 3)
            {
                IBuyer rebel = new Rebel
                    (currentBuyerData[0], int.Parse(currentBuyerData[1]), currentBuyerData[2]);

                buyers[i] = rebel;
            }
        }

        return buyers;
    }
}

