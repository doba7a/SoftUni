﻿using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 1.5;
    private const double REGENERATION_BONUS = 10;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(Helmet)
        };

    public Ranker(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => OVERALL_SKILL_MULTIPLIER;

    protected override double RegenerationBonus => REGENERATION_BONUS;

    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;
}

