using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            string itemName = type;

            Assembly assembly = Assembly.GetCallingAssembly();

            Type itemType = assembly.GetTypes().FirstOrDefault(t => t.Name == itemName);

            if (itemType == null || !typeof(Item).IsAssignableFrom(itemType))
            {
                throw new ArgumentException(string.Format(Messages.InvalidItemType, itemName));
            }

            Item item = (Item)Activator.CreateInstance(itemType, null);

            return item;
        }
    }
}
