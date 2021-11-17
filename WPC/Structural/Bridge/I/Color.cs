using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Bridge.I
{
    public abstract class Color
    {
        public abstract string ColorValue { get; }

        public override string ToString()
        {
            return ColorValue;
        }
    }
}
