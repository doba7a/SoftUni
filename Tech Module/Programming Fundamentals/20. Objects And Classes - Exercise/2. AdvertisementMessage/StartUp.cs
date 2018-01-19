namespace AdvertisementMessage
{
    using System;

    public class AdvertisementMessage
    {
        public static void Main()
        {
            string[] phrasesArray = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] eventsArray = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authorsArray = new string[]
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            string[] cityArray = new string[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            Random rnd = new Random();

            int numberOfMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfMessages; i++)
            {
                string phraseGenerated = phrasesArray[rnd.Next(0, phrasesArray.Length)];
                string eventGenerated = eventsArray[rnd.Next(0, eventsArray.Length)];
                string authorGenerated = authorsArray[rnd.Next(0, authorsArray.Length)];
                string cityGenerated = cityArray[rnd.Next(0, cityArray.Length)];

                string currentMessage = $"{phraseGenerated} {eventGenerated} {authorGenerated} - {cityGenerated}";

                Console.WriteLine(currentMessage);
            }
        }
    }
}