using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Facade.II
{
    public class ShoppingFacade
    {
        private ICartService _cartService;
        private IProductService _productService;
        private IPaymentService _paymentService;

        public ShoppingFacade(ICartService cartService, IProductService productService, IPaymentService paymentService)
        {
            _cartService = cartService;
            _productService = productService;
            _paymentService = paymentService;
        }

        public bool Buy(int[] productIds, int cartId)
        {
            foreach (var id in productIds)
            {
                _cartService.AddProduct(id, _productService.GetPrice(id));
            }

            var amount = _cartService.GetPrice(cartId);
            if (amount > 300)
                amount *= 0.9f;

            return _paymentService.Pay(cartId, amount);
        }
    }
}
