using NUnit.Framework;
using System.Linq;
using System.Reflection;

[TestFixture]
public class RemoveMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
    }

    [Test]
    public void DatabaseRemoveMethodTest()
    {
        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        int[] expectedValues = ((int[])fieldInfo.GetValue(this.db)).Take(15).ToArray();

        this.db.Remove();
        int[] valuesInDatabase = (int[])fieldInfo.GetValue(this.db);

        Assert.That(expectedValues, Is.EquivalentTo(valuesInDatabase), "Remove method doesn't work correct.");
    }

    [Test]
    public void DatabaseRemoveMethodThrowsExceptionOnEmptyDatabaseTest()
    {
        for (int i = 0; i < 16; i++)
        {
            this.db.Remove();
        }

        Assert.That(() => this.db.Remove(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Database already empty. No elements to remove."));
    }
}

