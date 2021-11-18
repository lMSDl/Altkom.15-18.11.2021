using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.ProvateClassData
{
    public class PrivateClassData
    {
        private int _value1;
        private int _value2;

        public PrivateClassData(int value1, int value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public int GetValue1()
        {
            return _value1;
        }
        public int GetValue2()
        {
            return _value2;
        }
    }
}
