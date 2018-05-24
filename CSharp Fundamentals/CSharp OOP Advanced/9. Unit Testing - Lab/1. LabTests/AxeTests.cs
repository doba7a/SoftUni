using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AXE_DAMAGE = 10;
    private const int AXE_DURABILITY = 1;
    private const int DUMMY_HEALTH = 5;
    private const int DUMMY_EXPERIENCE = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(AXE_DAMAGE, AXE_DURABILITY);
        this.dummy = new Dummy(DUMMY_HEALTH, DUMMY_EXPERIENCE);
    }

    [Test]
    public void WeaponLosesDurabilityAfterAttackTest()
    {
        int expectedDurability = this.axe.DurabilityPoints - 1;
        this.axe.Attack(dummy);

        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(expectedDurability), "Axe doesn't lose durability after attack");
    }

    [Test]
    public void AttackWithBrokenWeaponThrowsExceptionTest()
    {
        this.axe.Attack(this.dummy);
   
        Assert.That(() => this.axe.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}

