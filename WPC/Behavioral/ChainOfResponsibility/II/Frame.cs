using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.II
{
    public class Frame : Container
    {

        protected override void Click(bool handled)
        {
            Console.WriteLine("Frame: zmieniłam kolor");

            base.Click(handled);
        }

    }
}

