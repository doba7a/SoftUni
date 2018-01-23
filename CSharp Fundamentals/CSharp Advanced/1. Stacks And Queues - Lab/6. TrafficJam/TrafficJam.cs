namespace TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class TrafficJam
    {
        public static void Main()
        {
            int carsPassPerGreenLight = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsPassPerGreenLight; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
