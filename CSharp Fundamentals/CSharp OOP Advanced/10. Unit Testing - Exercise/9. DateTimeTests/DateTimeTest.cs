using System;
using NUnit.Framework;

[TestFixture]
public class DateTimeTest
{
    private IDatetime customDateTime;

    [SetUp]
    public void TestInit()
    {
        this.customDateTime = new CustomDateTime();
    }

    [Test]
    public void NowShouldReturnCurrentDate()
    {
        DateTime expectedValue = DateTime.Now.Date;

        Assert.AreEqual(expectedValue, this.customDateTime.Now().Date);
    }

    [Test]
    public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
    {
        DateTime testDate = new DateTime(2000, 10, 31);
        DateTime expectedDate = new DateTime(2000, 11, 1);

        testDate = testDate.AddDays(1);

        Assert.AreEqual(expectedDate, testDate);
    }
}
