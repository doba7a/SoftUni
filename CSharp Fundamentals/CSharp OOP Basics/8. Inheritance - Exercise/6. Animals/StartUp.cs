using System;

public class StartUp
{
    public static void Main()
    {
        while (true)
        {
            string animalType = Console.ReadLine();

            if (animalType == "Beast!")
            {
                break;
            }

            try
            {
                Animal animal = GetAnimal(animalType);

                Console.Write(animal.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static Animal GetAnimal(string animalType)
    {
        string[] inputData = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string animalName = inputData[0];
        int animalAge = int.Parse(inputData[1]);

        switch (animalType)
        {
            case "Cat":
                return new Cat(animalName, animalAge, inputData[2]);
            case "Dog":
                return new Dog(animalName, animalAge, inputData[2]);
            case "Frog":
                return new Frog(animalName, animalAge, inputData[2]);
            case "Kitten":
                return new Kitten(animalName, animalAge);
            case "Tomcat":
                return new Tomcat(animalName, animalAge);
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}