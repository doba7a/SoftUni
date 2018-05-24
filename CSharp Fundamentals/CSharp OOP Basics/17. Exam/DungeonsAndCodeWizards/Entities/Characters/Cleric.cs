using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Contracts;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const int CLERIC_BASE_HEALTH = 50;
        private const int CLERIC_BASE_ARMOR = 25;
        private const int CLERIC_ABILITY_POINTS = 40;

        public Cleric(string name, Faction faction) 
            : base(name, CLERIC_BASE_HEALTH, CLERIC_BASE_ARMOR, CLERIC_ABILITY_POINTS, new Backpack(), faction)
        {
        }

        public void Heal(Character character)
        {
            CheckIfCharacterIsAlive(this);

            CheckIfCharacterIsAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Messages.CannotHealEnemy);
            }

            character.HealCharacter(this.AbilityPoints);
        }

        public override double RestHealMultiplier { get => base.RestHealMultiplier; protected set => base.RestHealMultiplier = 0.5; }
    }
}
