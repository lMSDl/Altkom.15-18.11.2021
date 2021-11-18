using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Strategy
{
    public class Calculator
    {
        public ICalcStrategy Strategy { get; set; }

        public float? Operate(float value1, float value2)
        {
            return Strategy?.Calculate(value1, value2);
        }
    }
}
