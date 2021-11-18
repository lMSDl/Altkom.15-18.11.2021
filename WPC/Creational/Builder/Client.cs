using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Builder
{
    public class Client
    {
        public static void Execute()
        {
            //var vehicle = new Vehicle(4, 5, 4, 500, 100);

            //var builder = new VehicleBuilder();
            //builder.SetWeels(4);
            //builder.SetDoors(5);
            //builder.SetSeets(4);
            //builder.SetEngine(100);
            //builder.SetTrunk(500);
            //var vehicle = builder.Build();

            //var vehicle = new Vehicle.VehicleBuilder()
            //    .SetWeels(4)
            //    .SetDoors(5)
            //    .SetSeets(4)
            //    .SetEngine(100)
            //    .SetTrunk(500)
            //    .Build();

            var vehicle = new Vehicle.VehicleBuilderFacade()
                .Components
                    .SetWeels(4)
                    .SetDoors(5)
                    .SetSeets(4)
                .Manufacture
                    .SetManufacturer("Altkom")
                    .SetProductionDate(DateTime.Today)
                .Components
                    .SetEngine(100)
                    .SetTrunk(500)
                .Build();

            Console.WriteLine(vehicle);
        }
    }
}
