namespace CubicAssault
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CubicAssault
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> meteorsData = new Dictionary<string, Dictionary<string, long>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "Count em all")
            {
                string[] inputData = currentInput
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string regionName = inputData[0];
                string meteorType = inputData[1];
                int meteorCount = int.Parse(inputData[2]);

                if (!meteorsData.ContainsKey(regionName))
                {
                    meteorsData[regionName] = new Dictionary<string, long>();

                    meteorsData[regionName].Add("Green", 0);
                    meteorsData[regionName].Add("Red", 0);
                    meteorsData[regionName].Add("Black", 0);
                }

                meteorsData[regionName][meteorType] += meteorCount;

                ReduceMeteors(meteorsData[regionName]);

                currentInput = Console.ReadLine();
            }

            foreach (var region in meteorsData.OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key))
            {
                string regionName = region.Key;
                Dictionary<string, long> meteorsForCurrentRegion = region.Value;

                Console.WriteLine(regionName);

                foreach (var meteor in meteorsForCurrentRegion.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        public static void ReduceMeteors(Dictionary<string, long> currentRegionData)
        {
            while (currentRegionData["Green"] >= 1000000)
            {
                currentRegionData["Green"] -= 1000000;
                currentRegionData["Red"]++;
            }

            while (currentRegionData["Red"] >= 1000000)
            {
                currentRegionData["Red"] -= 1000000;
                currentRegionData["Black"]++;
            }
        }
    }
}
