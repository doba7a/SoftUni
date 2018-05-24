public interface IWeaponFactory
{
    IWeapon CreateWeapon(Rarity weaponRarity, string typeOfWeapon, string weaponName);
}

