namespace TrainingHallEquipment
{
    using System;

    public class TrainingHallEquipment
    {
        public static void Main()
        {
            var balance = double.Parse(Console.ReadLine());
            var boughtsNeeded = int.Parse(Console.ReadLine());
            var subtotal = 0.0;

            for (int i = 0; i < boughtsNeeded; i++)
            {
                var itemName = Console.ReadLine();
                var itemPrice = double.Parse(Console.ReadLine());
                var itemQuantity = int.Parse(Console.ReadLine());

                if (itemQuantity > 1)
                {
                    itemName += "s";
                }

                Console.WriteLine($"Adding {itemQuantity} {itemName} to cart.");

                balance -= itemPrice * itemQuantity;
                subtotal += itemPrice * itemQuantity;
            }

            Console.WriteLine($"Subtotal: ${subtotal:F2}");

            if (balance >= 0)
            {
                Console.WriteLine($"Money left: ${balance:F2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${Math.Abs(balance):F2} more.");
            }
        }
    }
}