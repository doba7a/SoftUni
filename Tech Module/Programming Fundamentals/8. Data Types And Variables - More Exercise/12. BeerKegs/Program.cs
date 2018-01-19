namespace BeerKegs
{
    using System;

    public class BeerKegs
    {
        public static void Main()
        {
            int totalKegs = int.Parse(Console.ReadLine());

            string biggestKegModel = string.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < totalKegs; i++)
            {
                string currentKegModel = Console.ReadLine();
                double currentKegRadius = double.Parse(Console.ReadLine());
                int currentKegHeight = int.Parse(Console.ReadLine());

                double currentKegVolume = Math.PI * currentKegRadius * currentKegRadius * currentKegHeight;

                if (currentKegVolume >= biggestKegVolume)
                {
                    biggestKegVolume = currentKegVolume;
                    biggestKegModel = currentKegModel;
                }
            }

            Console.WriteLine(biggestKegModel);
        }
    }
}