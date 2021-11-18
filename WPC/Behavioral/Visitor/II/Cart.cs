using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Visitor.II
{
    public class Cart : Basket
    {
        public override void Add(Product product)
        {
            Console.WriteLine("Produkt w wózku");
        }

        public override void Add(BoxedProduct product)
        {
            Console.WriteLine("Całe opakowanie produktu w wózku");
        }
    }
}
