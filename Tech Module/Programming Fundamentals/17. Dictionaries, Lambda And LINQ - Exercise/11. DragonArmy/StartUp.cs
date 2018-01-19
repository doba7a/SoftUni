namespace DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonStats
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    public class DragonArmy
    {
        public static void Main()
        {
            var resultDict = new Dictionary<string, SortedDictionary<string, DragonStats>>();

            var numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var currentInput = Console.ReadLine().Split(' ').ToList();

                var currentDragonType = currentInput[0];
                var currentDragonName = currentInput[1];
                var currentDragonDamage = 0;
                var currentDragonHealth = 0;
                var currentDragonArmor = 0;

                if (currentInput[2] == "null")
                {
                    currentDragonDamage = 45;
                }
                else
                {
                    currentDragonDamage = int.Parse(currentInput[2]);
                }

                if (currentInput[3] == "null")
                {
                    currentDragonHealth = 250;
                }
                else
                {
                    currentDragonHealth = int.Parse(currentInput[3]);
                }

                if (currentInput[4] == "null")
                {
                    currentDragonArmor = 10;
                }
                else
                {
                    currentDragonArmor = int.Parse(currentInput[4]);
                }

                var currentDragonStats = new DragonStats
                {
                    Damage = currentDragonDamage,
                    Health = currentDragonHealth,
                    Armor = currentDragonArmor
                };

                if (!resultDict.ContainsKey(currentDragonType))
                {
                    resultDict[currentDragonType] = new SortedDictionary<string, DragonStats>();
                }

                if (!resultDict[currentDragonType].ContainsKey(currentDragonName))
                {
                    resultDict[currentDragonType][currentDragonName] = new DragonStats();
                }

                resultDict[currentDragonType][currentDragonName] = currentDragonStats;
            }

            foreach (var dragonType in resultDict)
            {
                var currentType = dragonType.Key;
                var currentTypeAverageDamage = dragonType.Value.Values.Average(x => x.Damage);
                var currentTypeAverageHealth = dragonType.Value.Values.Average(x => x.Health);
                var currentTypeAverageArmor = dragonType.Value.Values.Average(x => x.Armor);

                Console.WriteLine($"{currentType}::({currentTypeAverageDamage:F2}/{currentTypeAverageHealth:F2}/{currentTypeAverageArmor:F2})");

                foreach (var dragon in dragonType.Value)
                {
                    var currentDragonName = dragon.Key;
                    var currentDragonDamage = dragon.Value.Damage;
                    var currentDragonHealth = dragon.Value.Health;
                    var currentDragonArmor = dragon.Value.Armor;

                    Console.WriteLine($"-{currentDragonName} -> damage: {currentDragonDamage}, health: {currentDragonHealth}, armor: {currentDragonArmor}");
                }
            }
        }
    }
}