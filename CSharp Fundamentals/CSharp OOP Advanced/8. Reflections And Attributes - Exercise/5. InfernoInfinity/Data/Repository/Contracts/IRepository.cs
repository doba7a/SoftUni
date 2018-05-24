using System;
using System.Collections.Generic;

public interface IRepository
{
    List<IWeapon> Weapons { get; }

    void Add(IWeapon weapon, IGem gem, int sockedIndex);

    void Create(IWeapon weapon);

    void Print(IWeapon weapon);

    void Remove(IWeapon weapon, int socketIndex);
}

