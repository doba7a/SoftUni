public class Knife : Weapon
{
    private const int KNIFE_MIN_DAMAGE = 3;
    private const int KNIFE_MAX_DAMAGE = 4;
    private const int KNIFE_SOCKETS = 2;

    public Knife(Rarity weaponRarity, string name)
        : base(weaponRarity, name, KNIFE_MIN_DAMAGE, KNIFE_MAX_DAMAGE, KNIFE_SOCKETS)
    {
    }
}
