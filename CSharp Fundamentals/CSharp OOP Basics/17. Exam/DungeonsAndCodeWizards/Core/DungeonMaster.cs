using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> itemPool;
        private IList<Character> characters;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.itemPool = new Stack<Item>();
            this.characters = new List<Character>();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characters.Add(character);

            return string.Format(Messages.PlayerJoined, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            Item item = this.itemFactory.CreateItem(itemType);

            this.itemPool.Push(item);

            return string.Format(Messages.ItemAdded, itemType);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            this.CharacterInParty(characterName);

            Character character = this.characters.First(c => c.Name == characterName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(Messages.EmptyItemPool);
            }

            Item item = this.itemPool.Pop();

            character.ReceiveItem(item);

            return string.Format(Messages.ItemPicked, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];

            this.CharacterInParty(characterName);

            Character character = this.characters.First(c => c.Name == characterName);

            string itemName = args[1];

            Item item = character.Bag.GetItem(itemName);

            item.AffectCharacter(character);

            return string.Format(Messages.ItemUsed, characterName, item.GetType().Name);
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];

            this.CharacterInParty(giverName);
            this.CharacterInParty(receiverName);

            Character giver = this.characters.First(c => c.Name == giverName);
            Character receiver = this.characters.First(c => c.Name == receiverName);

            string itemName = args[2];

            Item item = giver.Bag.GetItem(itemName);

            item.AffectCharacter(receiver);

            return string.Format(Messages.ItemUsedOn, giverName, item.GetType().Name, receiverName);
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];

            this.CharacterInParty(giverName);
            this.CharacterInParty(receiverName);

            Character giver = this.characters.First(c => c.Name == giverName);
            Character receiver = this.characters.First(c => c.Name == receiverName);

            string itemName = args[2];

            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return string.Format(Messages.ItemGiven, giverName, receiverName, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
          
            foreach (Character character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            this.CharacterInParty(attackerName);
            this.CharacterInParty(receiverName);

            Character attacker = this.characters.First(c => c.Name == attackerName);
            Character receiver = this.characters.First(c => c.Name == receiverName);

            if (attacker is Warrior warrior)
            {
                warrior.Attack(receiver);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format(Messages.AttackData,
                    warrior.Name,
                    receiver.Name,
                    warrior.AbilityPoints,
                    receiver.Name,
                    receiver.Health,
                    receiver.BaseHealth,
                    receiver.Armor,
                    receiver.BaseArmor));
                if (!receiver.IsAlive)
                {
                    sb.AppendLine(string.Format(Messages.AttackKilled, receiver.Name));
                }

                return sb.ToString().Trim();
            }
            else
            {
                throw new ArgumentException(string.Format(Messages.AttackerCannotAttack, attackerName));
            }
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            this.CharacterInParty(healerName);
            this.CharacterInParty(receiverName);

            Character healer = this.characters.First(c => c.Name == healerName);
            Character receiver = this.characters.First(c => c.Name == receiverName);

            if (healer is Cleric cleric)
            {
                cleric.Heal(receiver);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format(Messages.HealingData,
                    cleric.Name,
                    receiver.Name,
                    cleric.AbilityPoints,
                    receiver.Name,
                    receiver.Health));

                return sb.ToString().Trim();
            }
            else
            {
                throw new ArgumentException(string.Format(Messages.HealerCannotHeal, healerName));
            }
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character character in this.characters.Where(c => c.IsAlive == true))
            {
                double healthBeforeRest = character.Health;

                character.Rest();

                sb.AppendLine(string.Format(Messages.RestData, character.Name, healthBeforeRest, character.Health));
            }

            if (this.characters.Where(c => c.IsAlive == true).Count() < 2)
            {
                this.lastSurvivorRounds++;
            }
            else
            {
                this.lastSurvivorRounds = 0;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRounds >= 2)
            {
                return true;
            }

            return false;
        }

        private void CharacterInParty(string characterName)
        {
            if (this.characters.FirstOrDefault(c => c.Name == characterName) == null)
            {
                throw new ArgumentException(string.Format(Messages.CharacterNotFound, characterName));
            }
        }
    }
}
