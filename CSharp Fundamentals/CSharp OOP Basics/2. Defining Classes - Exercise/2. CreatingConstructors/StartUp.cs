using System;

public class StartUp
{
    public static void Main()
    {
        Person firstPerson = new Person();
        Console.WriteLine($"{firstPerson.Name}, {firstPerson.Age}");

        Person secondPerson = new Person(20);
        Console.WriteLine($"{secondPerson.Name}, {secondPerson.Age}");

        Person thirdPerson = new Person("gosho", 25);
        Console.WriteLine($"{thirdPerson.Name}, {thirdPerson.Age}");
    }
}
