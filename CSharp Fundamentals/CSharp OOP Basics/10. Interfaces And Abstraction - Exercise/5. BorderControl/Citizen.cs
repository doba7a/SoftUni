public class Citizen : IInhabitant
{
    private string name;
    private int age;
    private string id;

    public Citizen(string name, int age, string id)
    {
        this.name = name;
        this.age = age;
        this.Id = id;
    }

    public string Id { get => id; private set => id = value; }

    public bool ValidId(string id, string lastDigitsOfFakeIds)
    {
        if (!id.EndsWith(lastDigitsOfFakeIds))
        {
            return true;
        }

        return false;
    }
}

