using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
