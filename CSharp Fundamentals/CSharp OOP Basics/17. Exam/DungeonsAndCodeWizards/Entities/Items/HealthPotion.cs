using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HEALTH_POTION_WEIGHT = 5;
        private const int HEALTH_POTION_HEALING = 20;

        public HealthPotion() 
            : base(HEALTH_POTION_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.HealCharacter(HEALTH_POTION_HEALING);
        }
    }
}
