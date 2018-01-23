namespace PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            int numberOfPlants = int.Parse(Console.ReadLine());

            List<long> plantsPesticide = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            int[] days = new int[numberOfPlants];

            Stack<int> indexesToRemove = new Stack<int>();
            indexesToRemove.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                int maxDays = 0;

                while (indexesToRemove.Count > 0 
                    && plantsPesticide[indexesToRemove.Peek()] >= plantsPesticide[i])
                {
                    maxDays = Math.Max(maxDays, days[indexesToRemove.Pop()]);
                }

                if (indexesToRemove.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexesToRemove.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
