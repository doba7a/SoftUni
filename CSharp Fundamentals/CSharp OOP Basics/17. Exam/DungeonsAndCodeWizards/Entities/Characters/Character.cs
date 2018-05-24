using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Enums;
using System;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private double restHealMultiplier;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Messages.InvalidCharacterName);
                }

                name = value;
            }
        }

        public double BaseHealth { get => baseHealth; protected set => baseHealth = value; }

        public double Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                this.health = Math.Min(Math.Max(value, 0), BaseHealth);
            }
        }

        public double BaseArmor { get => baseArmor; protected set => baseArmor = value; }

        public double Armor { get => armor; protected set => armor = value; }

        public double AbilityPoints { get => abilityPoints; protected set => abilityPoints = value; }

        public Bag Bag { get => bag; protected set => bag = value; }

        public Faction Faction { get => faction; protected set => faction = value; }

        public bool IsAlive { get; protected set; } = true;

        public virtual double RestHealMultiplier { get => restHealMultiplier; protected set => restHealMultiplier = value; }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfCharacterIsAlive(this);

            CheckIfCharacterIsAlive(character);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfCharacterIsAlive(this);

            this.Bag.AddItem(item);
        }

        public void Rest()
        {
            CheckIfCharacterIsAlive(this);

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void TakeDamage(double hitPoints)
        {
            CheckIfCharacterIsAlive(this);

            if (this.Armor > 0)
            {
                double initialHitPoints = hitPoints;

                if (this.Armor >= hitPoints)
                {
                    hitPoints = 0;
                }
                else
                {
                    hitPoints -= this.Armor;
                }

                this.Armor = Math.Max(0, this.Armor - initialHitPoints);
            }

            this.Health -= hitPoints;

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            CheckIfCharacterIsAlive(this);

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfCharacterIsAlive(this);

            CheckIfCharacterIsAlive(character);

            item.AffectCharacter(character);
        }

        public void HealCharacter(double healing)
        {
            CheckIfCharacterIsAlive(this);

            this.Health += healing;
        }

        public void PoisonCharacter(double poison)
        {
            CheckIfCharacterIsAlive(this);

            this.Health -= poison;

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void RepairArmor()
        {
            CheckIfCharacterIsAlive(this);

            this.Armor = this.BaseArmor;
        }

        protected void CheckIfCharacterIsAlive(Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Messages.DeadCharacter);
            }
        }

        public override string ToString()
        {
            string aliveStatus = this.IsAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {aliveStatus}";
        }
    }
}
