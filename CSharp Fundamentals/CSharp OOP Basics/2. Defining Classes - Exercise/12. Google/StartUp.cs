using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> personData = new List<Person>();

        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string personName = inputData[0];

            if (!personData.Any(p => p.Name == personName))
            {
                Person currentPerson = new Person(personName);

                personData.Add(currentPerson);
            }

            string infromationAbout = inputData[1];

            switch (infromationAbout)
            {
                case "company":
                    Company currentPersonCompany = new Company(inputData[2], inputData[3], double.Parse(inputData[4]));

                    personData.FirstOrDefault(p => p.Name == personName).Company = currentPersonCompany;

                    break;
                case "pokemon":
                    Pokemon pokemonToAdd = new Pokemon(inputData[2], inputData[3]);

                    personData.FirstOrDefault(p => p.Name == personName).Pokemons.Add(pokemonToAdd);

                    break;
                case "parents":
                    Parent parentToAdd = new Parent(inputData[2], inputData[3]);

                    personData.FirstOrDefault(p => p.Name == personName).Parents.Add(parentToAdd);

                    break;
                case "children":
                    Child childToAdd = new Child(inputData[2], inputData[3]);

                    personData.FirstOrDefault(p => p.Name == personName).Children.Add(childToAdd);

                    break;
                case "car":
                    Car currentPersonCar = new Car(inputData[2], int.Parse(inputData[3]));

                    personData.FirstOrDefault(p => p.Name == personName).Car = currentPersonCar;

                    break;  
            }

            input = Console.ReadLine();
        }

        string personDataToPrint = Console.ReadLine();

        Console.WriteLine(personData.FirstOrDefault(p => p.Name == personDataToPrint));
    }
}

