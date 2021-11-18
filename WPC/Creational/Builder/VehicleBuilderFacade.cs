using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Builder
{
    public partial class Vehicle {
        public class VehicleBuilderFacade : VehicleBuilderBase
        {
            public VehicleBuilderFacade() : base(new Vehicle())
            {
            }
            protected VehicleBuilderFacade(Vehicle vehicle) : base(vehicle)
            {
            }


            public VehicleBuilder Components => new VehicleBuilder(Vehicle);
            public VehicleInfoBuilder Manufacture => new VehicleInfoBuilder(Vehicle);


        }
    }
}
