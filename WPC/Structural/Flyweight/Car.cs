using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Flyweight
{
    public class Car
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public string Company { get => CarFlyweight.Company; set => CarFlyweight.Company = value; }
        public string Model { get => CarFlyweight.Model; set => CarFlyweight.Model = value; }
        public Color Color { get => CarFlyweight.Color; set => CarFlyweight.Color = value; }

        public CarFlyweight CarFlyweight { get; set; } = new CarFlyweight();
    }
}
