namespace NumberWars
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Card
    {
        public string Name { get; set; }

        public int NumericValue { get; set; }

        public int LetterValue { get; set; }
    }

    public class NumberWars
    {
        public static void Main()
        {
            Queue<Card> firstPlayerDeck = ReadDeck();
            Queue<Card> secondPlayerDeck = ReadDeck();

            int turns = 0;

            while (turns < 1000000 && firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0)
            {
                Card firstPlayerCard = firstPlayerDeck.Dequeue();
                Card secondPlayerCard = secondPlayerDeck.Dequeue();

                if (firstPlayerCard.NumericValue > secondPlayerCard.NumericValue)
                {
                    firstPlayerDeck.Enqueue(firstPlayerCard);
                    firstPlayerDeck.Enqueue(secondPlayerCard);
                }
                else if (firstPlayerCard.NumericValue < secondPlayerCard.NumericValue)
                {
                    secondPlayerDeck.Enqueue(secondPlayerCard);
                    secondPlayerDeck.Enqueue(firstPlayerCard);
                }
                else if (firstPlayerCard.NumericValue == secondPlayerCard.NumericValue)
                {
                    List<Card> cardsAtTheTable = new List<Card>();
                    cardsAtTheTable.Add(firstPlayerCard);
                    cardsAtTheTable.Add(secondPlayerCard);

                    while (true)
                    {
                        if (firstPlayerDeck.Count >= 3 && secondPlayerDeck.Count >= 3)
                        {
                            int firstPlayerSum = 0;
                            int secondPlayerSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                Card firstPlayerDrawnCard = firstPlayerDeck.Dequeue();
                                firstPlayerSum += firstPlayerDrawnCard.LetterValue;

                                Card secondPlayerDrawnCard = secondPlayerDeck.Dequeue();
                                secondPlayerSum += secondPlayerDrawnCard.LetterValue;

                                cardsAtTheTable.Add(firstPlayerDrawnCard);
                                cardsAtTheTable.Add(secondPlayerDrawnCard);
                            }

                            if (firstPlayerSum > secondPlayerSum)
                            {
                                foreach (Card card in cardsAtTheTable
                                    .OrderByDescending(x => x.NumericValue)
                                    .ThenByDescending(x => x.LetterValue))
                                {
                                    firstPlayerDeck.Enqueue(card);
                                }

                                break;
                            }
                            else if (firstPlayerSum < secondPlayerSum)
                            {
                                foreach (Card card in cardsAtTheTable
                                    .OrderByDescending(x => x.NumericValue)
                                    .ThenByDescending(x => x.LetterValue))
                                {
                                    secondPlayerDeck.Enqueue(card);
                                }

                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Draw after {turns + 1} turns");
                            Environment.Exit(0);
                        }
                    }
                }

                turns++;
            }

            if (firstPlayerDeck.Count == 0 || (turns == 1000000 && firstPlayerDeck.Count < secondPlayerDeck.Count))
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else if (secondPlayerDeck.Count == 0 || (turns == 1000000 && firstPlayerDeck.Count > secondPlayerDeck.Count))
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
        }

        public static Queue<Card> ReadDeck()
        {
            Queue<Card> deckToReturn = new Queue<Card>();

            string[] inputData = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string card in inputData)
            {
                Card currentCard = new Card()
                {
                    Name = card,
                    NumericValue = GetNumericValue(card),
                    LetterValue = GetLetterValue(card)
                };

                deckToReturn.Enqueue(currentCard);
            }

            return deckToReturn;
        }

        public static int GetNumericValue(string name)
        {
            int numericValue = int.Parse(name.Substring(0, name.Length - 1));

            return numericValue;
        }

        public static int GetLetterValue(string name)
        {
            int letterValue = name.Last();

            return letterValue;
        }
    }
}
