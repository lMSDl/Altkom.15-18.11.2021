using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Composite
{
    public class Container : ProductBase
    {
        private readonly ICollection<ProductBase> _content;

        public Container(string name) : base(name)
        {
            _content = new List<ProductBase>();
        }

        public void Add(ProductBase product)
        {
            _content.Add(product);
        }

        public override float GetPrice()
        {
            var price = _content.Sum(x => x.GetPrice());
            Console.WriteLine($"{Name} ma wartość: {price}");
            return price;
        }
    }
}
