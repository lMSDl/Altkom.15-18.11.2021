using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Builder
{
    public partial class Vehicle {
        public abstract class VehicleBuilderBase
        {
            protected Vehicle Vehicle { get; }

            protected VehicleBuilderBase(Vehicle vehicle)
            {
                Vehicle = vehicle;
            }
            public Vehicle Build()
            {
                return Vehicle;
            }
        }
    }
}
