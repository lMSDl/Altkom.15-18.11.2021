using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Visitor.II
{
    public class BoxedProduct : Product
    {
        public override void PrintType()
        {
            Console.WriteLine("BoxedProduct");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
