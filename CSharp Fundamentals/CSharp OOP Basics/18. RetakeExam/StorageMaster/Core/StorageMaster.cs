using StorageMaster.Entities.Products;
using StorageMaster.Factories;
using StorageMaster.Constants;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> productsPool;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private List<Storage> storages;
        private Vehicle selectedVehicle;
 
        public StorageMaster()
        {
            this.productsPool = new Dictionary<string, Stack<Product>>
            {
                { "Gpu", new Stack<Product>() },
                { "HardDrive", new Stack<Product>() },
                { "Ram", new Stack<Product>() },
                { "SolidStateDrive", new Stack<Product>() }
            };
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.storages = new List<Storage>();
            this.selectedVehicle = null;
        }

        public string AddProduct(string type, double price)
        {
            Product newProduct = this.productFactory.CreateProduct(type, price);

            this.productsPool[type].Push(newProduct);

            return string.Format(Messages.ProductAdded, type);
        }

        public string RegisterStorage(string type, string name)
        {
            Storage newStorage = this.storageFactory.CreateStorage(type, name);

            this.storages.Add(newStorage);

            return string.Format(Messages.StorageRegistered, name);
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Vehicle vehicleToSelect = this.storages.FirstOrDefault(s => s.Name == storageName).GetVehicle(garageSlot);

            this.selectedVehicle = vehicleToSelect;

            return string.Format(Messages.VehicleSelected, selectedVehicle.GetType().Name);
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProducts = 0;

            foreach (string productName in productNames)
            {
                if (this.productsPool[productName].Count == 0)
                {
                    throw new InvalidOperationException(string.Format(Messages.ProductOutOfStock, productName));
                }

                if (!this.selectedVehicle.IsFull)
                {
                    Product product = this.productsPool[productName].Pop();
                    this.selectedVehicle.LoadProduct(product);
                    loadedProducts++;
                }             
            }

            return string.Format(Messages.VehicleLoaded, loadedProducts, productNames.Count(), this.selectedVehicle.GetType().Name);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storages.FirstOrDefault(s => s.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException(Messages.InvalidSourceStorage);
            }

            Storage destionationStorage = this.storages.FirstOrDefault(s => s.Name == destinationName);

            if (destionationStorage == null)
            {
                throw new InvalidOperationException(Messages.InvalidDestionationStorage);
            }

            Vehicle vehicleSent = sourceStorage.GetVehicle(sourceGarageSlot);
            int newGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destionationStorage);

            return string.Format(Messages.VehicleSent, vehicleSent.GetType().Name, destionationStorage.Name, newGarageSlot);
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.First(s => s.Name == storageName);

            int totalProducts = storage.GetVehicle(garageSlot).Trunk.Count;
            int unloadedProducts = storage.UnloadVehicle(garageSlot);

            return string.Format(Messages.VehicleUnloaded, unloadedProducts, totalProducts, storage.Name);
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages.First(s => s.Name == storageName);

            return storage.StorageSummary();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Storage storage in this.storages.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                sb.AppendLine(storage.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
