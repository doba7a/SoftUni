public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunitions(string ammunitionName, int quantity);

    bool TryEquipSoldier(ISoldier soldier);
}