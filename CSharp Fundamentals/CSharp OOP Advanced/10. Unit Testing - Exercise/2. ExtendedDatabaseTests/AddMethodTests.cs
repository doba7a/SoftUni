using NUnit.Framework;

[TestFixture]
public class AddMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database();
    }

    [TestCase("gosho", 4342412)]
    [TestCase("pesho", 4231232)]
    public void DatabaseValidAddMethodTest(string personUsername, long personId)
    {
        Person personToAdd = new Person(personUsername, personId);
        this.db.Add(personToAdd);

        Assert.That(this.db.GetDbCount(), Is.EqualTo(1), "Add method doesn't add persons.");
    }

    [TestCase("gosho", 4342412, "Gosho", 422312)]
    [TestCase("pesho", 4231232, "Pesho", 213214)]
    public void DatabaseAddMethodCaseSensitiveTest(string personUsername, long personId, string secondPersonUsername, long secondPersonId)
    {
        Person personToAdd = new Person(personUsername, personId);
        this.db.Add(personToAdd);

        Person secondPersonToAdd = new Person(secondPersonUsername, secondPersonId);
        this.db.Add(secondPersonToAdd);

        Assert.That(this.db.GetDbCount(), Is.EqualTo(2), "Add method doesn't add persons.");
    }

    [TestCase("gosho", 4342412, "gosho", 422312)]
    [TestCase("pesho", 4231232, "pesho", 213214)]
    public void DatabaseAddMethodExistingUsernameExceptionTest(string personUsername, long personId, string secondPersonUsername, long secondPersonId)
    {
        Person personToAdd = new Person(personUsername, personId);

        this.db.Add(personToAdd);

        Person secondPersonToAdd = new Person(secondPersonUsername, secondPersonId);
        Assert.That(() => this.db.Add(personToAdd), 
            Throws.InvalidOperationException.With.Message.EqualTo("Username taken."));
    }

    [TestCase("gosho", 4342412, "pesho", 4342412)]
    [TestCase("pesho", 4231232, "gosho", 4231232)]
    public void DatabaseAddMethodExistingIdExceptionTest(string personUsername, long personId, string secondPersonUsername, long secondPersonId)
    {
        Person personToAdd = new Person(personUsername, personId);

        this.db.Add(personToAdd);

        Person secondPersonToAdd = new Person(secondPersonUsername, secondPersonId);
        Assert.That(() => this.db.Add(secondPersonToAdd),
            Throws.InvalidOperationException.With.Message.EqualTo("ID taken."));
    }

    [TestCase("gosho", -4342412)]
    [TestCase("pesho", -4231232)]
    public void DatabaseAddMethodNegativeIdTest(string personUsername, long personId)
    {
        Person personToAdd = new Person(personUsername, personId);

        Assert.That(() => this.db.Add(personToAdd),
            Throws.ArgumentException.With.Message.EqualTo("ID can't be less than zero."));
    }
}

