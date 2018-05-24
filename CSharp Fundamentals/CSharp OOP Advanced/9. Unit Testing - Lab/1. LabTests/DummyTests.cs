using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DUMMY_HEALTH = 15;
    private const int DUMMY_EXPERIENCE = 10;

    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(DUMMY_HEALTH, DUMMY_EXPERIENCE);
    }

    [TestCase(5)]
    public void DummyLosesHealthWhenAttackedTest(int dummyDamageToTake)
    {
        int expectedHealth = this.dummy.Health - dummyDamageToTake;
        this.dummy.TakeAttack(dummyDamageToTake);

        Assert.That(this.dummy.Health, Is.EqualTo(expectedHealth), "Dummy health doesn't change after attack");
    }

    [TestCase(15)]
    public void DeadDummyThrowsExceptionIfAttackedTest(int dummyDamageToTake)
    {
        while (!this.dummy.IsDead())
        {
            this.dummy.TakeAttack(dummyDamageToTake);
        }

        Assert.That(() => this.dummy.TakeAttack(dummyDamageToTake), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveExperienceTest()
    {
        while (!this.dummy.IsDead())
        {
            this.dummy.TakeAttack(5);
        }

        Assert.That(this.dummy.GiveExperience(), Is.EqualTo(DUMMY_EXPERIENCE), "Dead dummy doesn't give experience");
    }

    [Test]
    public void AliveDummyCannotGiveExperienceTest()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}

