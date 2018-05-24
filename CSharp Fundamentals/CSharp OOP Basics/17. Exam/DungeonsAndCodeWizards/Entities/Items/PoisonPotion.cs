using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Contracts;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int POISON_POTION_WEIGHT = 5;
        private const int POISON_POTION_DAMAGE = 20;

        public PoisonPotion() 
            : base(POISON_POTION_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.PoisonCharacter(POISON_POTION_DAMAGE);
        }
    }
}
