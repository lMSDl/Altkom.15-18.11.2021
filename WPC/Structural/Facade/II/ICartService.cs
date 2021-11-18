using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Facade.II
{
    public interface ICartService
    {
        float GetPrice(int cartId);
        float AddProduct(int productId, float price);
    }
}
