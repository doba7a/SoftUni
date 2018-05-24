using System;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(Rarity weaponRarity, string typeOfWeapon, string weaponName)
    {
        Type classType = Type.GetType(typeOfWeapon);

        IWeapon currentWeapon = (IWeapon)Activator.CreateInstance(classType, new object[] { weaponRarity, weaponName });

        return currentWeapon;
    }
}

