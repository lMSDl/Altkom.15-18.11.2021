using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.I
{
    public class Client
    {
        public static void Execute()
        {
            var handler5 = new DiscountHandler(null, 500, 4500, "5");
            var handler4 = new DiscountHandler(handler5, 500, 5000, "4");
            var handler3 = new DiscountHandler(handler4, 200, 8000, "3");
            //var handler2 = new DiscountHandler(handler3, 100, 8000, "2");
            var handler1 = new DiscountHandler(handler3, 100, 10000, "1");


            Console.WriteLine(handler1.Discount(250, 8000));

            Console.WriteLine(handler1.Discount(1000, 8000));

            Console.WriteLine(handler3.Discount(50, 10000));
        }
    }
}