using System.Collections.Generic;
using StorageMaster.Factories;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;
        private const string AutomatedWarehouseVehicleType = "Truck";

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, CreateVehicles())
        {
        }

        private static IEnumerable<Vehicle> CreateVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            return new List<Vehicle>() { vehicleFactory.CreateVehicle(AutomatedWarehouseVehicleType) };
        }
    }
}
