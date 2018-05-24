using NUnit.Framework;

class FetchMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
    }

    [Test]
    public void DatabaseFetchMethodReturnsArrayOfIntegersTest()
    {
        Assert.That(this.db.Fetch().GetType(), Is.EqualTo(typeof(int[])), "Fetch method doesn't return array of integers");
    }
}
