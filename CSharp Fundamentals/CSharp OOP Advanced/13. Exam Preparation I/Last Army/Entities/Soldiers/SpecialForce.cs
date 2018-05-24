using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 3.5;
    private const double REGENERATION_BONUS = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(RPG),
            nameof(Helmet),
            nameof(Knife),
            nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => OVERALL_SKILL_MULTIPLIER;

    protected override double RegenerationBonus => REGENERATION_BONUS;

    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;
}
