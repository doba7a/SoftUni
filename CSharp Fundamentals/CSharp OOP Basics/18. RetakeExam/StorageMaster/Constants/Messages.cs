namespace StorageMaster.Constants
{
    public static class Messages
    {
        public const string NegativePrice = "Price cannot be negative!";

        public const string FullVehicle = "Vehicle is full!";

        public const string FullGarage = "No room in garage!";

        public const string FullStorage = "Storage is full!";

        public const string EmptyVehicle = "No products left in vehicle!";

        public const string EmptySlot = "No vehicle in this garage slot!";

        public const string InvalidSlot = "Invalid garage slot!";

        public const string InvalidProduct = "Invalid product type!";

        public const string InvalidStorage = "Invalid storage type!";

        public const string InvalidVehicle = "Invalid vehicle type!";

        public const string InvalidSourceStorage = "Invalid source storage!";

        public const string InvalidDestionationStorage = "Invalid destination storage!";

        public const string ProductAdded = "Added {0} to pool";

        public const string StorageRegistered = "Registered {0}";

        public const string VehicleSelected = "Selected {0}";

        public const string VehicleLoaded = "Loaded {0}/{1} products into {2}";

        public const string VehicleUnloaded = "Unloaded {0}/{1} products at {2}";

        public const string VehicleSent = "Sent {0} to {1} (slot {2})";

        public const string ProductOutOfStock = "{0} is out of stock!";

        public const string StorageStockFormat = "Stock ({0}/{1}): [{2}]";

        public const string StorageGarageFormat = "Garage: [{0}]";

        public const string StorageToStringFormat = "{0}:{1}Storage worth: ${2:F2}";
    }
}
