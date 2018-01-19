namespace PopulationCounter
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class PopulationCounter
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> populationData
                = new Dictionary<string, Dictionary<string, long>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "report")
            {
                List<string> currentInputData = currentInput.Split('|').ToList();

                string currentInputCountry = currentInputData[1];

                if (!populationData.ContainsKey(currentInputCountry))
                {
                    populationData[currentInputCountry] = new Dictionary<string, long>();
                }

                string currentInputCity = currentInputData[0];

                if (!populationData[currentInputCountry].ContainsKey(currentInputCity))
                {
                    populationData[currentInputCountry][currentInputCity] = 0;
                }

                long currentCityPopulation = long.Parse(currentInputData[2]);

                populationData[currentInputCountry][currentInputCity] += currentCityPopulation;

                currentInput = Console.ReadLine();
            }

            foreach (var country in populationData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                string currentCountryName = country.Key;
                long currentCountryPopulation = country.Value.Values.Sum();

                Console.WriteLine($"{currentCountryName} (total population: {currentCountryPopulation})");

                Dictionary<string, long> currentCountryData = country.Value;

                foreach (var city in currentCountryData.OrderByDescending(x => x.Value))
                {
                    string currentCityName = city.Key;
                    long currentCityPopulation = city.Value;

                    Console.WriteLine($"=>{currentCityName}: {currentCityPopulation}");
                }
            }
        }
    }
}