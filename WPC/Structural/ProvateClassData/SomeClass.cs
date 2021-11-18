using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.ProvateClassData
{
    public class SomeClass
    {
        //private int _value1;
        //private int _value2;
        private PrivateClassData _privateClassData;

        public SomeClass(int value1, int value2)
        {
            _privateClassData = new PrivateClassData(value1, value2);
        }

        public int GetValue1()
        {
            return _privateClassData.GetValue1();
        }
        public int GetValue2()
        {
            return _privateClassData.GetValue2();
        }

        public void DoSth()
        {
            //_value1 = 3;
            //_value2 = 1;
        }

    }
}
