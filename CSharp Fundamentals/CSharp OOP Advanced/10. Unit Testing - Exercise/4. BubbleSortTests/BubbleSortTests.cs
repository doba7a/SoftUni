using NUnit.Framework;
using System;

[TestFixture]
public class BubbleSortTests
{
    [TestCase(new int[] { 6, 5, 4, 3, 2, 1 })]
    [TestCase(new int[] { 12, 4235, 1, 423, 312, 5, 0, -5, 32 })]
    public void BubbleSortWorksCorrectlyWithIntegersTest(int[] values)
    {
        int[] bubbleSortArray = values;
        Bubble.Sort(bubbleSortArray);

        int[] legacySortArray = values;
        Array.Sort(legacySortArray);

        Assert.That(bubbleSortArray, Is.EquivalentTo(legacySortArray), "Bubble sort doesn't work correctly.");
    }

    [TestCase(new double[] { 6.1, 6.05, 6.07, 1.5, 2.1, 4.7 })]
    [TestCase(new double[] { 12.54235, 12.423, 1.131245, 423.32, 423.333, 5.13, 0, -5.11, -5.12 })]
    public void BubbleSortWorksCorrectlyWithDoublesTest(double[] values)
    {
        double[] bubbleSortArray = values;
        Bubble.Sort(bubbleSortArray);

        double[] legacySortArray = values;
        Array.Sort(legacySortArray);

        Assert.That(bubbleSortArray, Is.EquivalentTo(legacySortArray), "Bubble sort doesn't work correctly.");
    }

    [Test]
    public void BubbleSortWorksCorrectlyWithStringsTest()
    {
        string[] values = new string[] { "qnko", "pochivka", "ot", "gosho", "pena", "stamat", "anka", "Gosho", "Ot", "Pochivka", "1.1", "1" };

        string[] bubbleSortArray = values;
        Bubble.Sort(bubbleSortArray);

        string[] legacySortArray = values;
        Array.Sort(legacySortArray);

        Assert.That(bubbleSortArray, Is.EquivalentTo(legacySortArray), "Bubble sort doesn't work correctly.");
    }
}

