using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Memento
{
    public class Person : ICloneable, IRestorable<Person>
    {
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }

        //public Memento<Person> Memento()
        //{
        //    return new Memento<Person>((Person)Clone());
        //}

        //public void Restore(Memento<Person> memento)
        //{
        //    BirthDate = memento.State.BirthDate;
        //    Name = memento.State.Name;
        //}

        public void Restore(Person state)
        {
            BirthDate = state.BirthDate;
            Name = state.Name;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
