public class StartUp
{
    public static void Main()
    {
        Person firstPerson = new Person
        {
            Name = "Pesho",
            Age = 20
        };

        Person secondPerson = new Person();
        secondPerson.Name = "Gosho";
        secondPerson.Age = 30;
    }
}

