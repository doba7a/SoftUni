using NUnit.Framework;

[TestFixture]
public class FindByIdMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database();
        this.db.Add(new Person("gosho", 32423));
    }

    [TestCase("gosho", 32423)]
    public void DatabaseFindByIdMethodValidTest(string personUsername, long personId)
    {
        Person searchedPerson = this.db.FindById(personId);

        Assert.That(searchedPerson, Is.SameAs(this.db.FindByUsername(personUsername)), "FindById method gives wrong result.");
    }

    [TestCase(-32423)]
    public void DatabaseFindByIdMethodNegativeIdTest(long personId)
    {
        Assert.That(() => this.db.FindById(personId), 
            Throws.ArgumentException.With.Message.EqualTo("ID can't be less than zero."));
    }

    [TestCase(3242)]
    public void DatabaseFindByIdMethodNonexistentIdTest(long personId)
    {
        Assert.That(() => this.db.FindById(personId),
            Throws.InvalidOperationException.With.Message.EqualTo($"Person with ID: {personId} doesn't exist in database."));
    }
}
