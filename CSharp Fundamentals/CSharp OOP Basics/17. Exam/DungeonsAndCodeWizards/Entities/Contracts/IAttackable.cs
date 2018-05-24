using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Contracts
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
