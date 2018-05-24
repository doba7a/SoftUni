using System;
using System.Collections.Generic;

public class WeaponRepository : IRepository
{
    private List<IWeapon> weapons;

    public WeaponRepository()
    {
        this.Weapons = new List<IWeapon>();
    }

    public List<IWeapon> Weapons { get => weapons; private set => weapons = value; }

    public void Add(IWeapon weapon, IGem gem, int socketIndex)
    {
        weapon.Gems[socketIndex] = gem;
    }

    public void Create(IWeapon weapon)
    {
        Weapons.Add(weapon);
    }

    public void Remove(IWeapon weapon, int socketIndex)
    {
        weapon.Gems[socketIndex] = null;
    }

    public void Print(IWeapon weapon)
    {
        Console.WriteLine(weapon);
    }
}

