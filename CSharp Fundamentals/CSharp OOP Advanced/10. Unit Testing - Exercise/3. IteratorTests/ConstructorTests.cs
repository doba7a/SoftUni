using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ConstructorTests
{
    [Test]
    public void IteratorConstructorValidTest()
    {
        List<string> inputCollection = new List<string>() { "gosho", "pesho", "stamat" };

        Iterator iterator = new Iterator(inputCollection);

        Assert.That(iterator, Is.EquivalentTo(inputCollection), "Constructor doesn't work correct.");
    }

    [Test]
    public void IteratorConstructorThrowsExceptionOnNullCollectionTest()
    {
        List<string> inputCollection = null;

        Assert.Throws<ArgumentNullException>(() => new Iterator(inputCollection));
    }

    [Test]
    public void IteratorConstructorThrowsExceptionOnNullElementTest()
    {
        List<string> inputCollection = new List<string>() { "gosho", null, "stamat" };

        Assert.That(() => new Iterator(inputCollection),
            Throws.ArgumentNullException.With.Message.EqualTo("Elements cannot be null."));
    }
}
