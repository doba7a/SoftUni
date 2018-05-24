using StorageMaster.Constants;
using System;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(Messages.NegativePrice);
                }

                this.price = value;
            }
        }

        public double Weight { get => weight; protected set => weight = value; }
    }
}
