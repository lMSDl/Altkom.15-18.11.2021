using System;

namespace WPC.Behavioral.Visitor.I
{
    public class Client
    {
        public static void Execute()
        {
            var collection = new IElement[] {
            new PlainText { Plain = "plain" },
            new PlainText { Plain = "\n" },
            new BoldText { Bold = "bold" },
            new PlainText { Plain = "\n" },
            new Hyperlink { Url = "http:\\some.url.com", Label="Some Url Company" }
            };


            var visitor = new HtmlVisitor();

            foreach (var item in collection)
            {
                item.Accept(visitor);
            }
            Console.WriteLine(visitor.Output);
        }
    }
}
