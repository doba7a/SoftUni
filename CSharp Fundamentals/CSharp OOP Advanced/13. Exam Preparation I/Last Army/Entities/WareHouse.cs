using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitions;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }
    
    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        List<string> wornOutWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        bool fullyEquipedSoldiers = true;

        foreach (string weapon in wornOutWeapons)
        {
            if (this.ammunitions.ContainsKey(weapon) && ammunitions[weapon] > 0)
            {
                IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(weapon);

                soldier.Weapons[weapon] = ammunition;
                this.ammunitions[weapon]--;
            }
            else
            {
                fullyEquipedSoldiers = false;
            }
        }

        return fullyEquipedSoldiers;
    }

    public void AddAmmunitions(string ammunitionName, int quantity)
    {
        if (!this.ammunitions.ContainsKey(ammunitionName))
        {
            this.ammunitions[ammunitionName] = 0;
        }

        this.ammunitions[ammunitionName] += quantity;
    }
}

