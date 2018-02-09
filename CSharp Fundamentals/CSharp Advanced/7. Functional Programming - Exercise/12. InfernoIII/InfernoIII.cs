namespace InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InfernoIII
    {
        public static void Main()
        {
            List<int> gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            ExecuteCommands(gems);

            Console.WriteLine(string.Join(" ", gems));
        }

        public static void ExecuteCommands(List<int> gems)
        {
            string[] input = Console.ReadLine().Split(';');
            Queue<KeyValuePair<string, int>> exclusionFilters = new Queue<KeyValuePair<string, int>>();

            while (input[0] != "Forge")
            {
                if (input.Length < 3)
                {
                    input = Console.ReadLine().Split(';');
                    continue;
                }

                string command = input[0];
                string filterType = input[1];
                int filterParamenter = int.Parse(input[2]);

                switch (command)
                {
                    case "Exclude":
                        exclusionFilters.Enqueue(new KeyValuePair<string, int>(filterType, filterParamenter));
                        break;

                    case "Reverse":
                        if (exclusionFilters.Count > 0)
                        {
                            exclusionFilters.Dequeue();
                        }
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(';');
            }

            ExecuteExclusions(gems, exclusionFilters);
        }

        public static void ExecuteExclusions(List<int> gems, Queue<KeyValuePair<string, int>> exclusionFilters)
        {
            foreach (var filter in exclusionFilters.Reverse())
            {
                switch (filter.Key)
                {
                    case "Sum Left":
                        FilterLeft(filter.Value, gems);
                        break;

                    case "Sum Right":
                        FilterRight(filter.Value, gems);
                        break;

                    case "Sum Left Right":
                        FilterLeftRight(filter.Value, gems);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void FilterLeftRight(int value, List<int> gems)
        {
            for (int i = 0; i < gems.Count; i++)
            {
                int leftGemPower = (i == 0) ? 0 : gems[i - 1];
                int rightGemPower = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (leftGemPower + gems[i] + rightGemPower == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void FilterRight(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.Last() == value)
            {
                gems.RemoveAt(gems.Count - 1);
            }

            for (int i = 0; i < gems.Count; i++)
            {
                int rightNum = (i == gems.Count - 1) ? 0 : gems[i + 1];

                if (gems[i] + rightNum == value)
                {
                    gems.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void FilterLeft(int value, List<int> gems)
        {
            while (gems.Count > 0 && gems.First() == value)
            {
                gems.RemoveAt(0);
            }

            for (int i = gems.Count - 1; i >= 0; i--)
            {
                int leftNum = (i > 0) ? gems[i - 1] : 0;

                if (gems[i] + leftNum == value)
                {
                    gems.RemoveAt(i);
                }
            }
        }
    }
}
