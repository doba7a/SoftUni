namespace LegendaryFarming
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class LegendaryFarming
    {
        public static void Main()
        {
            Dictionary<string, int> keyMaterials =
                new Dictionary<string, int>()
                {
                    {"shards", 0 },
                    {"fragments", 0 },
                    {"motes", 0 }
                };

            Dictionary<string, int> junkMaterials =
                new Dictionary<string, int>();

            while (true)
            {
                List<string> currentMaterials = Console.ReadLine().Split(' ').ToList();

                for (int i = 0; i < currentMaterials.Count; i += 2)
                {
                    int currentMaterialCount = int.Parse(currentMaterials[i]);
                    string currentMaterial = currentMaterials[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(currentMaterial))
                    {
                        keyMaterials[currentMaterial] += currentMaterialCount;

                        if (keyMaterials[currentMaterial] >= 250)
                        {
                            keyMaterials[currentMaterial] -= 250;
                            PrintResult(keyMaterials, junkMaterials, currentMaterial);
                            Environment.Exit(1);                  
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(currentMaterial))
                        {
                            junkMaterials[currentMaterial] = 0;
                        }

                        junkMaterials[currentMaterial] += currentMaterialCount;
                    }
                }
            }
        }

        public static void PrintResult(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials, string currentMaterial)
        {
            switch (currentMaterial)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }

            foreach (var keyMaterial in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            foreach (var junkMaterial in junkMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }
    }
}