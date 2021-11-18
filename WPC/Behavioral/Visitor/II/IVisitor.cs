namespace WPC.Behavioral.Visitor.II
{
    public interface IVisitor
    {
        void Visit(Product product);
        void Visit(BoxedProduct product);
    }
}
