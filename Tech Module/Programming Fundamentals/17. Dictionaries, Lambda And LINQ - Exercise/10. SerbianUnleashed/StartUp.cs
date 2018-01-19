namespace SerbianUnsleashed
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public class SerbianUnsleashed
    {
        public static void Main()
        {
            var resultDictionary = new Dictionary<string, Dictionary<string, long>>();

            var pattern = @"(.+) @(.+) (\d+) (\d+)";
            var regex = new Regex(pattern);

            var input = Console.ReadLine();

            while (input != "End")
            {

                if (!regex.IsMatch(input))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var currentInputData = regex.Match(input);

                var singer = currentInputData.Groups[1].Value;
                var venue = currentInputData.Groups[2].Value;
                var ticketPrice = long.Parse(currentInputData.Groups[3].Value);
                var ticketCount = long.Parse(currentInputData.Groups[4].Value);

                if (singer.Split(' ').Length > 3 || venue.Split(' ').Length > 3)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!resultDictionary.ContainsKey(venue))
                {
                    resultDictionary[venue] = new Dictionary<string, long>();
                }

                if (!resultDictionary[venue].ContainsKey(singer))
                {
                    resultDictionary[venue][singer] = 0;
                }

                var moneyMade = ticketPrice * ticketCount;
                resultDictionary[venue][singer] += moneyMade;

                input = Console.ReadLine();
            }

            foreach (var venue in resultDictionary)
            {
                var currentVenue = venue.Key;
                var currentSingerData = venue.Value;

                Console.WriteLine($"{currentVenue}");

                foreach (var singer in currentSingerData.OrderByDescending(x => x.Value))
                {
                    var currentSinger = singer.Key;
                    var currentSingerProfit = singer.Value;

                    Console.WriteLine($"#  {currentSinger} -> {currentSingerProfit}");
                }
            }
        }
    }
}