using NUnit.Framework;
using System.Linq;
using System.Reflection;

[TestFixture]
public class AddMethodTests
{
    private Database db;

    [SetUp]
    public void TestInit()
    {
        this.db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
    }

    [Test]
    public void DatabaseAddMethodTest()
    {
        int valueToAdd = 20;
        this.db.Remove();
        this.db.Add(valueToAdd);

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        int[] expectedValues = ((int[])fieldInfo.GetValue(this.db)).Take(15).Concat(new int[] { valueToAdd }).ToArray();
        int[] valuesInDatabase = (int[])fieldInfo.GetValue(this.db);

        Assert.That(expectedValues, Is.EquivalentTo(valuesInDatabase), "Remove method doesn't work correct.");
    }

    [Test]
    public void DatabaseAddMethodThrowsExceptionIfDatabaseIsFullTest()
    {
        int valueToAdd = 20;

        Assert.That(() => this.db.Add(valueToAdd),
            Throws.InvalidOperationException.With.Message.EqualTo("Database can't store more than 16 integers."));
    }
}

