namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            long numberOfPumps = long.Parse(Console.ReadLine());

            Queue<string> queueOfPumps = new Queue<string>();

            for (long i = 0; i < numberOfPumps; i++)
            {
                string currentPump = Console.ReadLine();

                queueOfPumps.Enqueue(currentPump);
            }

            for (int i = 0; i < queueOfPumps.Count; i++)
            {
                long[] startingPumpData = queueOfPumps
                    .Peek()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long petrolLeft = startingPumpData[0] - startingPumpData[1];

                if (petrolLeft >= 0)
                {
                    for (int j = 1; j < queueOfPumps.Count; j++)
                    { 
                        long[] currentPumpData = queueOfPumps
                            .ElementAt(j)
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToArray();

                        petrolLeft = petrolLeft + currentPumpData[0] - currentPumpData[1];

                        if (petrolLeft < 0)
                        {
                            queueOfPumps.Enqueue(queueOfPumps.Dequeue());
                            break;
                        }

                        if (j == queueOfPumps.Count - 1)
                        {
                            Console.WriteLine(i);
                            Environment.Exit(1);
                        }
                    }
                }
                else
                {
                    queueOfPumps.Enqueue(queueOfPumps.Dequeue());
                }
            }
        }
    }
}
