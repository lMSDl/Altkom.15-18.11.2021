using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.I
{
    public class DiscountHandler : IDiscountHandler
    {
        protected IDiscountHandler NextHandler { get; }

        public float MaxDiscount { get; }

        public float MinPrice { get; }

        public string Name { get; set; }

        public DiscountHandler(IDiscountHandler nextHandler, float maxDiscount, float minPrice, string name)
        {
            NextHandler = nextHandler;
            MaxDiscount = maxDiscount;
            MinPrice = minPrice;
            Name = name;
        }

        public bool Discount(float value, float price)
        {
            if(price >= MinPrice && value <= MaxDiscount)
            {
                Console.WriteLine($"{Name} przyznał rabat {value} za wydanie {price}");
                return true;
            }
            if(NextHandler == null)
            {
                Console.WriteLine($"Rabat {value} za wydanie {price} nie został przyznany");
                return false;
            }

            Console.WriteLine($"Zapytanie przekazane dalej");
            return NextHandler.Discount(value, price);
        }
    }
}
