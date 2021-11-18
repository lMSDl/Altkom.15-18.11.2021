using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.II
{
    public abstract class Component
    {
        public Component Parent { get; set; }


        public void Click()
        {
            Click(false);
        }

        public int ClickEventsCounter { get; private set; }

        protected virtual void Click(bool handled)
        {
            ClickEventsCounter++;
            Parent?.Click(handled);
        }
    }
}

