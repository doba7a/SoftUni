public class Robot : IInhabitant
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        this.model = model;
        this.Id = id;
    }

    public string Id { get => id; private set => id = value; }
}
