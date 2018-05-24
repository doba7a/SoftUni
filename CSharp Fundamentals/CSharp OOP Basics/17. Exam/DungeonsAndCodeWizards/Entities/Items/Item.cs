using DungeonsAndCodeWizards.Entities.Characters;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            this.weight = weight;
        }

        public int Weight => this.weight;

        public abstract void AffectCharacter(Character character);
    }
}
