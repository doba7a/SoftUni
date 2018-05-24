using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class MoveMethodTests
{
    private Iterator iterator;

    [SetUp]
    public void TestInit()
    {
        this.iterator = new Iterator(new List<string>() { "gosho", "pesho", "stamat" });
    }

    [Test]
    public void IteratorMoveMethodReturnsTrueTest()
    {
        Assert.IsTrue(this.iterator.Move(), "Move method doesn't work correctly");
    }

    [Test]
    public void IteratorMoveMethodReturnsFalseTest()
    {
        for (int i = 0; i < 2; i++)
        {
            this.iterator.Move();
        }

        Assert.IsFalse(this.iterator.Move(), "Move method doesn't work correctly");
    }
}
