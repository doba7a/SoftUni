using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MAX_ENDURANCE = 100;

    private string name;
    private int age;
    private double experience;
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
        foreach (string weapon in this.WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }

    }

    public string Name { get => name; protected set => name = value; }

    public int Age { get => age; protected set => age = value; }

    public double Experience { get => experience; protected set => experience = value; }

    public double Endurance
    {
        get => endurance;
        protected set => endurance = Math.Min(MAX_ENDURANCE, value);
    }

    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (this.Age + this.Experience) * OverallSkillMultiplier;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract double RegenerationBonus { get; }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in Weapons.Values.Where(w => w != null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);

            if (weapon.WearLevel <= 0)
            {
                Weapons[weapon.Name] = null;
            }
        }

    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        if (!(this.Weapons.Values.Count(weapon => weapon == null) == 0))
        {
            return false;
        }

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + this.RegenerationBonus;
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}