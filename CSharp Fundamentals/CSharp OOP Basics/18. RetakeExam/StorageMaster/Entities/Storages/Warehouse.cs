using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System.Collections.Generic;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;
        private const string WareHouseVehicleType = "Semi";

        public Warehouse(string name)
            : base(name, WarehouseCapacity, WarehouseGarageSlots, CreateVehicles())
        {
        }

        private static IEnumerable<Vehicle> CreateVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            return new List<Vehicle>() { vehicleFactory.CreateVehicle(WareHouseVehicleType),
                vehicleFactory.CreateVehicle(WareHouseVehicleType),
                vehicleFactory.CreateVehicle(WareHouseVehicleType) };
        }
    }
}
