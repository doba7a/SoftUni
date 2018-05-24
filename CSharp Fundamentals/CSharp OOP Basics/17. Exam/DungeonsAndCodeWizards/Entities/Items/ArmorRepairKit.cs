using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class ArmorRepairKit : Item
    {
        private const int ARMOR_REPAIR_KIT_WEIGHT = 10;

        public ArmorRepairKit() 
            : base(ARMOR_REPAIR_KIT_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.RepairArmor();
        }
    }
}
