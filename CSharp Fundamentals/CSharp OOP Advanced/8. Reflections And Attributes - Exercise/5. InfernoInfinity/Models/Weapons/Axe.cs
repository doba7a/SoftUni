public class Axe : Weapon
{
    private const int AXE_MIN_DAMAGE = 5;
    private const int AXE_MAX_DAMAGE = 10;
    private const int AXE_SOCKETS = 4;

    public Axe(Rarity weaponRarity, string name)
        : base(weaponRarity, name, AXE_MIN_DAMAGE, AXE_MAX_DAMAGE, AXE_SOCKETS)
    {
    }
}
