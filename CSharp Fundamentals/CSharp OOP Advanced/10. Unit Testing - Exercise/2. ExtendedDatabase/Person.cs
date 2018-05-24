public class Person : IPerson
{
    private string username;
    private long id;

    public Person(string username, long id)
    {
        this.Username = username;
        this.Id = id;
    }

    public string Username { get => username; private set => username = value; }

    public long Id { get => id; private set => id = value; }
}

