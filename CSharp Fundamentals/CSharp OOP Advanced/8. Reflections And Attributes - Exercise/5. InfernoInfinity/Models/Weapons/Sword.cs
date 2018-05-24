public class Sword : Weapon
{
    private const int SWORD_MIN_DAMAGE = 4;
    private const int SWORD_MAX_DAMAGE = 6;
    private const int SWORD_SOCKETS = 3;

    public Sword(Rarity weaponRarity, string name)
        : base(weaponRarity, name, SWORD_MIN_DAMAGE, SWORD_MAX_DAMAGE, SWORD_SOCKETS)
    {
    }
}
