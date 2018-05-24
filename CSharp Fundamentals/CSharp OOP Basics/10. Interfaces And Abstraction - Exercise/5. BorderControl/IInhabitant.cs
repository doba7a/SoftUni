public interface IInhabitant
{
    string Id { get; }

    bool ValidId(string id, string lastDigitsOfFakeIds);
}

