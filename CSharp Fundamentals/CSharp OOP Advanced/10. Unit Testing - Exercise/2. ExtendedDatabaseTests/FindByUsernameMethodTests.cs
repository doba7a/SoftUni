using NUnit.Framework;

[TestFixture]
public class FindByUsernameTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database();
        this.db.Add(new Person("gosho", 32423));
    }

    [TestCase("gosho", 32423)]
    public void DatabaseFindByUsernameMethodValidTest(string personUsername, long personId)
    {
        Person searchedPerson = this.db.FindByUsername(personUsername);

        Assert.That(searchedPerson, Is.SameAs(this.db.FindById(personId)), "FindByUsername method gives wrong result.");
    }

    [TestCase(null)]
    [TestCase("")]
    public void DatabaseFindByUsernameMethodNullOrEmptyUsernameTest(string personUsername)
    {
        Assert.That(() => this.db.FindByUsername(personUsername),
            Throws.ArgumentNullException.With.Message.EqualTo("Given username can't be null or empty."));
    }

    [TestCase("pesho")]
    public void DatabaseFindByUsernameMethodNonexistentUsernameTest(string personUsername)
    {
        Assert.That(() => this.db.FindByUsername(personUsername),
            Throws.InvalidOperationException.With.Message.EqualTo($"Person with Username: {personUsername} doesn't exist in database."));
    }
}

