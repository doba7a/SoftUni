namespace Weather
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Weather
    {
        public static void Main()
        {
            List<CityWeatherData> weatherDataList = new List<CityWeatherData>();

            string pattern = @"([A-Z]{2})(\d+\.\d+)([A-Za-z]+\|)";

            string inputData = Console.ReadLine();

            while (inputData != "end")
            {
                if (!Regex.IsMatch(inputData, pattern))
                {
                    inputData = Console.ReadLine();
                    continue;
                }

                Match currentCityData = Regex.Match(inputData, pattern);

                string currentCityName = currentCityData.Groups[1].Value;
                double currentCityAverageTemp = double.Parse(currentCityData.Groups[2].Value);
                string currentCityWeatherType = currentCityData.Groups[3].Value.Remove(currentCityData.Groups[3].Value.Length - 1);

                if (weatherDataList.Any(x => x.CityName == currentCityName))
                {
                    CityWeatherData existingCityWeatherData = weatherDataList.First(x => x.CityName == currentCityName);

                    existingCityWeatherData.CityAverageTemp = currentCityAverageTemp;
                    existingCityWeatherData.CityWeatherType = currentCityWeatherType;
                }
                else
                {
                    CityWeatherData currentCityWeatherData = new CityWeatherData
                    {
                        CityName = currentCityName,
                        CityAverageTemp = currentCityAverageTemp,
                        CityWeatherType = currentCityWeatherType
                    };

                    weatherDataList.Add(currentCityWeatherData);
                }

                inputData = Console.ReadLine();
            }

            foreach (CityWeatherData city in weatherDataList.OrderBy(x => x.CityAverageTemp))
            {
                Console.WriteLine($"{city.CityName} => {city.CityAverageTemp:F2} => {city.CityWeatherType}");
            }
        }
    }

    public class CityWeatherData
    {
        public string CityName { get; set; }
        public double CityAverageTemp { get; set; }
        public string CityWeatherType { get; set; }
    }
}