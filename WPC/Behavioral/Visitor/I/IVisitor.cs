using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Visitor.I
{
    public interface IVisitor
    {
        void Visit(PlainText plainText);
        void Visit(BoldText boldText);
        void Visit(Hyperlink hyperlink);
    }
}
