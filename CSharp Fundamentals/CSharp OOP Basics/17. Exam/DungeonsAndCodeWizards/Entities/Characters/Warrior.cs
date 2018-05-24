using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Contracts;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const int WARRIOR_BASE_HEALTH = 100;
        private const int WARRIOR_BASE_ARMOR = 50;
        private const int WARRIOR_ABILITY_POINTS = 40;

        public Warrior(string name, Faction faction) 
            : base(name, WARRIOR_BASE_HEALTH, WARRIOR_BASE_ARMOR, WARRIOR_ABILITY_POINTS, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            CheckIfCharacterIsAlive(this);

            CheckIfCharacterIsAlive(character);

            if (this.Equals(character))
            {
                throw new InvalidOperationException(Messages.CannotAttackSelf);
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(Messages.FriendlyFire, this.Faction));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
