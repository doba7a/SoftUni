using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private const string HERO_NAME = "Hero";

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDiesTest()
    {
        var fakeTarget = new FakeDeadTarget();
        var fakeWeapon = new FakeWeapon();
        var hero = new Hero(HERO_NAME, fakeWeapon);

        hero.Attack(fakeTarget);
        var expectedExperience = fakeTarget.GiveExperience();

        Assert.AreEqual(expectedExperience, hero.Experience);
    }

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDiesTestMoqVersion()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(ft => ft.Health).Returns(0);
        fakeTarget.Setup(ft => ft.GiveExperience()).Returns(10);
        fakeTarget.Setup(ft => ft.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero(HERO_NAME, fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(10, hero.Experience);
    }
}
