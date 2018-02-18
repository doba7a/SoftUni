using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Cat> catsData = new List<Cat>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string catBreed = inputData[0];
            string catName = inputData[1];
            string breedSpecifics = inputData[2];

            Cat cat = new Cat(catBreed, catName);

            switch (catBreed)
            {
                case "Siamese":
                    cat = new Siamese(catBreed, catName, int.Parse(breedSpecifics));
                    break;
                case "Cymric":
                    cat = new Cymric(catBreed, catName, double.Parse(breedSpecifics));
                    break;
                case "StreetExtraordinaire":
                    cat = new Extraordinary(catBreed, catName, int.Parse(breedSpecifics));
                    break;
            }

            catsData.Add(cat);

            input = Console.ReadLine();
        }

        string catToPrintName = Console.ReadLine();

        Cat catSearched = catsData.FirstOrDefault(c => c.Name == catToPrintName);

        Console.WriteLine(catSearched.ToString());
    }
}

