using NUnit.Framework;
using System.Linq;
using System.Reflection;

[TestFixture]
class ConstructorTests
{
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
    [TestCase(new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
    public void ValidDatabaseConstructorDataTest(int[] valuesGiven)
    {
        Database db = new Database(valuesGiven);

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        int[] valuesInDatabase = (int[])fieldInfo.GetValue(db);

        Assert.That(valuesGiven, Is.EquivalentTo(valuesInDatabase), "Values given are not passed correctly through the constructor.");
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
    public void InvalidDatabaseConstructorDataThrowsExceptionTest(int[] valuesGiven)
    {
        Assert.That(() => new Database(valuesGiven),
            Throws.InvalidOperationException.With.Message.EqualTo("Size of the array must be exactly 16 integers long."));
    }
}

