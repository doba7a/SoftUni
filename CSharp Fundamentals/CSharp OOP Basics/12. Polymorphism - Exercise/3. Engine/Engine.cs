using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private static List<Animal> animals = new List<Animal>();
    private static Cat cat;
    private static Tiger tiger;
    private static Owl owl;
    private static Hen hen;
    private static Dog dog;
    private static Mouse mouse;

    public void GetFelines(string type, string name, double weight,string livingRegion, string breed, string nameOfFood, int quantity)
    {
        if (type == "Cat")
        {
            cat = new Cat(name, weight, 0, livingRegion, breed);
            cat.CanEat(nameOfFood, quantity);
            animals.Add(cat);
        }
        else
        {
            tiger = new Tiger(name, weight, 0, livingRegion, breed);
            tiger.CanEat(nameOfFood, quantity);
            animals.Add(tiger);
        }
    }

    public void GetBird(string type, string name, double weight, double wingSize, string nameOfFood, int quantity)
    {
        if (type == "Hen")
        {
            hen = new Hen(name, weight, 0, wingSize);
            hen.CanEat(nameOfFood, quantity);
            animals.Add(hen);
        }
        else
        {
            owl = new Owl(name, weight, 0, wingSize);
            owl.CanEat(nameOfFood, quantity);
            animals.Add(owl);
        }
    }

    public void GetMiceDog(string type, string name, double weight, string region, string nameOfFood, int quantity)
    {
        if (type == "Dog")
        {
            dog = new Dog(name, weight, 0, region);
            dog.CanEat(nameOfFood, quantity);
            animals.Add(dog);
        }
        else
        {
            mouse = new Mouse(name, weight, 0, region);
            mouse.CanEat(nameOfFood, quantity);
            animals.Add(mouse);
        }
    }

    public void PrintResult()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

