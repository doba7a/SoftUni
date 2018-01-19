using System;

namespace HandsOfCards
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class HandsOfCards
    {
        public static void Main()
        {
            Dictionary<string, HashSet<string>> pointsDictionary = new Dictionary<string, HashSet<string>>();

            string currentHand = Console.ReadLine();

            while (currentHand != "JOKER")
            {
                List<string> currentHandData = currentHand
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string currentPlayer = currentHandData[0];

                if (!pointsDictionary.ContainsKey(currentPlayer))
                {
                    pointsDictionary[currentPlayer] = new HashSet<string>();
                }

                List<string> currentHandCards = currentHandData[1]
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                foreach (string card in currentHandCards)
                {
                    pointsDictionary[currentPlayer].Add(card);
                }

                currentHand = Console.ReadLine();
            }

            foreach (var player in pointsDictionary)
            {
                int currentPlayerPoints = 0;

                foreach (string card in player.Value)
                {
                    currentPlayerPoints += GetCardPoints(card);
                }

                Console.WriteLine($"{player.Key}: {currentPlayerPoints}");
            }
        }

        public static int GetCardPoints(string card)
        {
            int points = 0;

            Dictionary<string, int> powerOfCards = new Dictionary<string, int>()
            {
                {"2", 2 },
                {"3", 3 },
                {"4", 4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9 },
                {"10", 10 },
                {"J", 11 },
                {"Q", 12 },
                {"K", 13 },
                {"A", 14 }
            };

            string currentCardPower = card.Substring(0, card.Length - 1);
            points += powerOfCards[currentCardPower];

            Dictionary<char, int> typeOfCards = new Dictionary<char, int>()
            {
                {'S', 4 },
                {'H', 3 },
                {'D', 2 },
                {'C', 1 }
            };

            char currentCardColour = card.Last();
            points *= typeOfCards[currentCardColour];

            return points;
        }
    }
}