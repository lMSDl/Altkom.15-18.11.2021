using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Prototype
{
    public class Person : ICloneable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public List<string> Addresses { get; set; }

        public object Clone()
        {
            var clone = (Person)MemberwiseClone();
            //clone.Addresses = Addresses.Clone();
            clone.Addresses = new List<string>(Addresses);
            return clone;
        }

        public object CloneShallow()
        {
            return MemberwiseClone();
        }


    }
    }
