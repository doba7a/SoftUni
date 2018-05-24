using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using System;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string productType, double productPrice)
        {
            switch (productType)
            {
                case "Gpu":
                    return new Gpu(productPrice);
                case "HardDrive":
                    return new HardDrive(productPrice);
                case "Ram":
                    return new Ram(productPrice);
                case "SolidStateDrive":
                    return new SolidStateDrive(productPrice);
                default:
                    throw new InvalidOperationException(Messages.InvalidProduct);
            }
        }
    }
}
