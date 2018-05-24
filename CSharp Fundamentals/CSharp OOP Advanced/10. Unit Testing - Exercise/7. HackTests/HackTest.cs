using Moq;
using NUnit.Framework;

public class MathTest
{
    [Test]
    public void TestMathAbsoluteMethod()
    {
        Mock<IMath> math = new Mock<IMath>();
        math.Setup(x => x.Abs(10, -20)).Returns(10);

        Assert.That(math.Object.Abs(10, -20), Is.EqualTo(10));
    }

    [Test]
    public void TestMathFloorMethod()
    {
        Mock<IMath> math = new Mock<IMath>();
        math.Setup(x => x.Floor(3.40)).Returns(3);

        Assert.That(math.Object.Floor(3.40), Is.EqualTo(3));
    }
}