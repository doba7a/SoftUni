using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity => capacity;

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(Messages.FullBag);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(Messages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(Messages.InvalidItemName, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
