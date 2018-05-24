using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System.Collections.Generic;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int DistributionCenterGarageSlots = 5;
        private const string DistributionCenterVehicleType = "Van";

        public DistributionCenter(string name)
            : base(name, DistributionCenterCapacity, DistributionCenterGarageSlots, CreateVehicles())
        {
        }

        private static IEnumerable<Vehicle> CreateVehicles()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            return new List<Vehicle>() { vehicleFactory.CreateVehicle(DistributionCenterVehicleType),
               vehicleFactory.CreateVehicle(DistributionCenterVehicleType),
               vehicleFactory.CreateVehicle(DistributionCenterVehicleType) };
        }
    }
}
