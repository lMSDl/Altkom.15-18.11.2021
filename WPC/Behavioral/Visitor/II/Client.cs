namespace WPC.Behavioral.Visitor.II
{
    public class Client
    {
        public static void Execute()
        {
            var products = new Product[] { new Product(), new BoxedProduct() };
            foreach (var item in products)
            {
                item.PrintType();
            }

            var baskets = new Basket[] { new Basket(), new Cart() };
            foreach (var product in products)
            {
                foreach (var basket in baskets)
                {
                    //basket.Add(product);
                    product.Accept(basket);
                }
            }
        }
    }
}
