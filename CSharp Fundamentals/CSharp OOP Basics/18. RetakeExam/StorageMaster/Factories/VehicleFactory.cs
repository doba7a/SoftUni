using StorageMaster.Constants;
using StorageMaster.Entities.Vehicles;
using System;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Truck":
                    return new Truck();
                case "Van":
                    return new Van();
                case "Semi":
                    return new Semi();
                default:
                    throw new InvalidOperationException(Messages.InvalidVehicle);
            }
        }
    }
}
