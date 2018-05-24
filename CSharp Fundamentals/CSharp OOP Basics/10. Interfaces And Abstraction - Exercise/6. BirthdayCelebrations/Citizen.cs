public class Citizen : IInhabitant, IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.name = name;
        this.age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Birthdate { get => birthdate; private set => birthdate = value; }
    public string Id { get => id; private set => id = value; }
}
