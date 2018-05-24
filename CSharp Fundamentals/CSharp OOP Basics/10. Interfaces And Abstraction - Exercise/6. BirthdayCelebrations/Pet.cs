public class Pet : IBirthable
{
    private string name;
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        this.name = name;
        this.Birthdate = birthdate;
    }

    public string Birthdate { get => birthdate; private set => birthdate = value; }
}

