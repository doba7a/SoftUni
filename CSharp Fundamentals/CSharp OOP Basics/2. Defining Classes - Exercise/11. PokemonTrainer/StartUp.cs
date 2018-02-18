using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Trainer> trainersData = new List<Trainer>();

        string input = Console.ReadLine();

        while (input != "Tournament")
        {
            string[] inputData = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string trainerName = inputData[0];

            if (!trainersData.Any(t => t.Name == trainerName))
            {
                Trainer currentTrainer = new Trainer(trainerName);

                trainersData.Add(currentTrainer);
            }

            string pokemonName = inputData[1];
            string pokemonElement = inputData[2];
            int pokemonHealth = int.Parse(inputData[3]);

            Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            trainersData.FirstOrDefault(t => t.Name == trainerName).Pokemons.Add(currentPokemon);

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != "End")
        {
            foreach (Trainer trainer in trainersData)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }

            input = Console.ReadLine();
        }

        foreach (Trainer trainer in trainersData.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}

