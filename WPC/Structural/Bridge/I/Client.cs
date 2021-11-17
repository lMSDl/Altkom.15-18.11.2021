using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Bridge.I
{
    public class Client
    {
        public static void Execute()
        {
            var shape = new Circle();
            Console.WriteLine(shape);

            var color = new RedColor();
            shape.Color = color;
            Console.WriteLine(shape);

        }
    }
}
