using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.AbstractFactory
{
    class Client
    {
        public static void Execute()
        {
            Order order;
            order = new Order(new HondaFactory(), nameof(ISedan), "compact");

            order = new Order(new ToyotaFactory(), nameof(ISuv), "full");
        }
   }
}
