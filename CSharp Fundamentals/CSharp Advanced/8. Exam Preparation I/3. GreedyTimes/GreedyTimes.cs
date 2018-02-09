namespace GreedyTimes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Treasure
    {
        public string Name { get; set; }
        public long Amount { get; set; }
    }

    public class GreedyTimes
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            Dictionary<string, List<Treasure>> bagContent = new Dictionary<string, List<Treasure>>();
            bagContent["Gold"] = new List<Treasure>();
            bagContent["Gem"] = new List<Treasure>();
            bagContent["Cash"] = new List<Treasure>();

            string[] safeData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < safeData.Length; i += 2)
            {
                string currentTreasureName = safeData[i].ToLower();
                long currentTreasureAmount = long.Parse(safeData[i + 1]);

                if (bagCapacity - currentTreasureAmount < 0)
                {
                    continue;
                }

                if (currentTreasureName == "gold")
                {
                    if (bagContent["Gold"].Any(x => x.Name.ToLower() == currentTreasureName))
                    {
                        bagContent["Gold"].First(x => x.Name.ToLower() == currentTreasureName).Amount += currentTreasureAmount;
                    }
                    else
                    {
                        Treasure currentTreasure = new Treasure()
                        {
                            Name = safeData[i],
                            Amount = currentTreasureAmount
                        };

                        bagContent["Gold"].Add(currentTreasure);
                    }

                    bagCapacity -= currentTreasureAmount;
                }
                else if (currentTreasureName.EndsWith("gem") && currentTreasureName.Length > 3)
                {
                    if (bagContent["Gem"].Sum(x => x.Amount) + currentTreasureAmount > bagContent["Gold"].Sum(x => x.Amount))
                    {
                        continue;
                    }

                    if (bagContent["Gem"].Any(x => x.Name.ToLower() == currentTreasureName))
                    {
                        bagContent["Gem"].First(x => x.Name.ToLower() == currentTreasureName).Amount += currentTreasureAmount;
                    }
                    else
                    {
                        Treasure currentTreasure = new Treasure()
                        {
                            Name = safeData[i],
                            Amount = currentTreasureAmount
                        };

                        bagContent["Gem"].Add(currentTreasure);
                    }

                    bagCapacity -= currentTreasureAmount;
                }
                else if (currentTreasureName.Length == 3)
                {
                    if (bagContent["Cash"].Sum(x => x.Amount) + currentTreasureAmount > bagContent["Gem"].Sum(x => x.Amount))
                    {
                        continue;
                    }

                    if (bagContent["Cash"].Any(x => x.Name.ToLower() == currentTreasureName))
                    {
                        bagContent["Cash"].First(x => x.Name.ToLower() == currentTreasureName).Amount += currentTreasureAmount;
                    }
                    else
                    {
                        Treasure currentTreasure = new Treasure()
                        {
                            Name = safeData[i],
                            Amount = currentTreasureAmount
                        };

                        bagContent["Cash"].Add(currentTreasure);
                    }

                    bagCapacity -= currentTreasureAmount;
                }
            }

            foreach (var typeTreasure in bagContent.OrderByDescending(x => x.Value.Sum(y => y.Amount)))
            {
                if (typeTreasure.Value.Count > 0)
                {
                    Console.WriteLine($"<{typeTreasure.Key}> ${typeTreasure.Value.Sum(x => x.Amount)}");

                    foreach (var currentTreasure in typeTreasure.Value.OrderByDescending(x => x.Name).ThenBy(y => y.Amount))
                    {
                        Console.WriteLine($"##{currentTreasure.Name} - {currentTreasure.Amount}");
                    }
                }
            }
        }
    }
}
