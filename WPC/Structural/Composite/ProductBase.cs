using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Composite
{
    public abstract class ProductBase
    {
        public string Name { get; }

        protected ProductBase(string name)
        {
            Name = name;
        }
        public abstract float GetPrice();
    }
}
