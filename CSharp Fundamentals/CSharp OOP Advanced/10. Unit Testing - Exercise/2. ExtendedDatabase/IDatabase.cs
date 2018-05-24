public interface IDatabase
{
    void Add(Person personToAdd);

    void Remove();

    Person FindByUsername(string username);

    Person FindById(long id);
}

