using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Builder
{
    public partial class Vehicle {
        public class VehicleInfoBuilder : VehicleBuilderFacade
        {
            public VehicleInfoBuilder(Vehicle vehicle) : base(vehicle)
            {
            }

            public VehicleInfoBuilder SetProductionDate(DateTime dateTime)
            {
                Vehicle.ProductionDate = dateTime;
                return this;
            }

            public VehicleInfoBuilder SetManufacturer(string manufacturer)
            {
                Vehicle.Manufacturer = manufacturer;
                return this;
            }
        }
    }
}
