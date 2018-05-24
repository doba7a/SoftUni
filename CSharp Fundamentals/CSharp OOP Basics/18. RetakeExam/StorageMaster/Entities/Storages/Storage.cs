using StorageMaster.Constants;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = this.CreateGarage(garageSlots, vehicles);
            this.products = new List<Product>();
        }

        public string Name { get => name; protected set => name = value; }

        public int Capacity { get => capacity; protected set => capacity = value; }

        public int GarageSlots { get => garageSlots; protected set => garageSlots = value; }

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity ? true : false;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(Messages.InvalidSlot);
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException(Messages.EmptySlot);
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (deliveryLocation.garage.All(gs => gs != null))
            {
                throw new InvalidOperationException(Messages.FullGarage);
            }

            this.garage[garageSlot] = null;

            int firstFreeSlot = 0;
            foreach (Vehicle slot in deliveryLocation.garage)
            {
                if (slot == null)
                {
                    break;
                }

                firstFreeSlot++;
            }

            deliveryLocation.garage[firstFreeSlot] = vehicle;

            return firstFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Messages.FullStorage);
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int numberOfUnloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                this.products.Add(vehicle.Unload());
                numberOfUnloadedProducts++;
            }

            return numberOfUnloadedProducts;
        }

        public string StorageSummary()
        {
            StringBuilder sb = new StringBuilder();

            double productsWeight = this.Products.Sum(p => p.Weight);

            int storageCapacity = this.Capacity;

            string products = string.Join(", ", this.Products
                .GroupBy(p => p.GetType().Name)
                .OrderByDescending(p => p.Count())
                .ThenBy(p => p.Key)
                .Select(p => $"{p.Key} ({p.Count()})"));

            string garageData = "";
            foreach (Vehicle vehicle in this.garage)
            {
                if (vehicle == null)
                {
                    garageData += "empty|";
                }
                else
                {
                    garageData += vehicle.GetType().Name + "|";
                }
            }

            garageData = garageData.Remove(garageData.Length - 1);

            sb.AppendLine(string.Format(Messages.StorageStockFormat, productsWeight, storageCapacity, products))
                .AppendLine(string.Format(Messages.StorageGarageFormat, garageData));

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return string.Format(Messages.StorageToStringFormat, this.Name, Environment.NewLine, this.products.Sum(p => p.Price));
        }

        private Vehicle[] CreateGarage(int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Vehicle[] garage = new Vehicle[garageSlots];

            int garageSlot = 0;
            foreach (Vehicle vehicle in vehicles)
            {
                garage[garageSlot++] = vehicle;
            }

            return garage;
        }
    }
}
