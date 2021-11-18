using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.II
{
    public abstract class Container : Component
    {
        protected ICollection<Component> Content { get; } = new List<Component>();

        public void Add(Component component)
        {
            Content.Add(component);
            component.Parent = this;
        }
    }
}
