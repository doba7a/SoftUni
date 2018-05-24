using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly Stack<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new Stack<Product>();
        }

        public int Capacity { get => capacity; protected set => capacity = value; }

        public IReadOnlyCollection<Product> Trunk => this.trunk;

        public bool IsFull => this.trunk.Sum(p => p.Weight) >= this.Capacity ? true : false;

        public bool IsEmpty => this.trunk.Count == 0 ? true : false;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Messages.FullVehicle);
            }

            this.trunk.Push(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(Messages.EmptyVehicle);
            }

            return this.trunk.Pop();
        }

        public override string ToString()
        {
            if (this == null)
            {
                return "empty";
            }

            return this.GetType().Name;
        }
    }
}
