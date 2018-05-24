using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Enums;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factionGiven, string type, string name)
        {
            string factionAsString = factionGiven;

            if (!Enum.TryParse<Faction>(factionAsString, out Faction faction))
            {
                throw new ArgumentException(string.Format(Messages.InvalidFaction, factionAsString));
            }

            string characterTypeAsString = type;
            string characterName = name;

            Assembly assembly = Assembly.GetCallingAssembly();

            Type characterType = assembly.GetTypes().FirstOrDefault(t => t.Name == characterTypeAsString);

            if (characterType == null || !typeof(Character).IsAssignableFrom(characterType))
            {
                throw new ArgumentException(string.Format(Messages.InvalidCharacterType, characterTypeAsString));
            }

            Character character = (Character)Activator.CreateInstance(characterType, new object[] { characterName, faction });

            return character;
        }
    }
}
