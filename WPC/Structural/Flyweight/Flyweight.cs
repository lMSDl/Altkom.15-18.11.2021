using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Flyweight
{
    public class CarFlyweight
    {

        public string Company { get; set; }

        public string Model { get; set; }

        public Color Color { get; set; }

        public void Operation(Car uniqueState)
        {
            string s = JsonConvert.SerializeObject(this);
            string u = JsonConvert.SerializeObject(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }
}
