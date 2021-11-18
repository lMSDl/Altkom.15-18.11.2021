using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Observer
{
    public class ObserverA : Observer<int>
    {
        public override void OnNext(int value)
        {
            if(value > 5 || value == 0)
                Console.WriteLine("ObserverA");
        }
    }
}
