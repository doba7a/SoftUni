using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class PrintMethodTests
{
    [Test]
    public void IteratorPrintMethodThrowsExceptionOnEmptyCollectionTest()
    {
        List<string> inputCollection = new List<string>();

        Iterator iterator = new Iterator(inputCollection);

        Assert.That(() => iterator.Print(),
            Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
    }

    [Test]
    public void IteratorPrintMethodValidTest()
    {
        List<string> inputCollection = new List<string>() { "gosho", "pesho", "stamat" };

        Iterator iterator = new Iterator(inputCollection);

        Assert.That(iterator.Print(), Is.EqualTo(inputCollection[0]), "Print method doesn't work correctly");
    }
}

