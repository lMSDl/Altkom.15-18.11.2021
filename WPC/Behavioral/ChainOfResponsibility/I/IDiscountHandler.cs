using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.I
{
    public interface IDiscountHandler
    {
        float MaxDiscount { get; }
        float MinPrice { get; }
        bool Discount(float value, float price);
    }
}
