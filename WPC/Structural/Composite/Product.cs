using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Composite
{
    public class Product : ProductBase, ICloneable
    {
        public float Price { get; }
        public Product(string name, float price) : base(name)
        {
            Price = price;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override float GetPrice()
        {
            Console.WriteLine($"{Name} kosztuje: {Price}");
            return Price;
        }
    }
}
