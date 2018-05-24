using NUnit.Framework;

[TestFixture]
public class RemoveMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database();
        this.db.Add(new Person("gosho", 32423));
    }

    [Test]
    public void DatabaseRemoveMethodValidTest()
    {
        this.db.Remove();

        Assert.That(this.db.GetDbCount(), Is.EqualTo(0), "Remove method doesn't remove persons correctly");
    }

    [Test]
    public void DatabaseRemoveMethodThrowsExceptionOnEmptyCollection()
    {
        this.db.Remove();

        Assert.That(() => this.db.Remove(),
            Throws.InvalidOperationException.With.Message.EqualTo("Database already empty."));
    }
}
