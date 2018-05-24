using System.Linq;

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private IGem[] gems;

    protected Weapon(Rarity weaponRarity, string name, int minDamage, int maxDamage, int numberOfSockets)
    {
        this.Name = name;
        this.MinDamage = minDamage * (int)weaponRarity;
        this.MaxDamage = maxDamage * (int)weaponRarity;
        this.Gems = new IGem[numberOfSockets];
    }

    public string Name { get => name; private set => name = value; }
    public int MinDamage { get => minDamage; private set => minDamage = value; }
    public int MaxDamage { get => maxDamage; private set => maxDamage = value; }
    public IGem[] Gems { get => gems; private set => gems = value; }

    public override string ToString()
    {
        string name = this.Name;
        int gemsStrength = this.Gems.Where(g => g != null).Sum(g => g.Strength);
        int gemsAgility = this.Gems.Where(g => g != null).Sum(g => g.Agility);
        int gemsVitality = this.Gems.Where(g => g != null).Sum(g => g.Vitality);
        int totalMinDamage = this.MinDamage + gemsStrength * 2 + gemsAgility;
        int totalMaxDamage = this.MaxDamage + gemsStrength * 3 + gemsAgility * 4;

        return $"{name}: {totalMinDamage}-{totalMaxDamage} Damage, +{gemsStrength} Strength, +{gemsAgility} Agility, +{gemsVitality} Vitality";
    }
}

