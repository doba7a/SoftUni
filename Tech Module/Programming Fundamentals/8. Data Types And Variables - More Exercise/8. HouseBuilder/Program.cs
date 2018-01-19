namespace HouseBuilder
{
    using System;

    public class HouseBuilder
    {
        public static void Main()
        {
            int firstPrice = int.Parse(Console.ReadLine());
            int secondPrice = int.Parse(Console.ReadLine());

            long sbytePrice = 0;
            long intPrice = 0;
            long totalPrice = 0;

            if (firstPrice < 128)
            {
                sbytePrice = firstPrice;
                intPrice = secondPrice;
                totalPrice = sbytePrice * 4 + intPrice * 10;
                Console.WriteLine(totalPrice);
            }
            else
            {
                sbytePrice = secondPrice;
                intPrice = firstPrice;
                totalPrice = sbytePrice * 4 + intPrice * 10;
                Console.WriteLine(totalPrice);
            }
        }
    }
}