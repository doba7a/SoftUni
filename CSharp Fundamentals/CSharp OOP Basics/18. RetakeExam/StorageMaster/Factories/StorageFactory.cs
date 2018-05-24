using StorageMaster.Constants;
using StorageMaster.Entities.Storages;
using System;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string storageType, string storageName)
        {
            switch (storageType)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(storageName);
                case "DistributionCenter":
                    return new DistributionCenter(storageName);
                case "Warehouse":
                    return new Warehouse(storageName);
                default:
                    throw new InvalidOperationException(Messages.InvalidStorage);
            }            
        }
    }
}
