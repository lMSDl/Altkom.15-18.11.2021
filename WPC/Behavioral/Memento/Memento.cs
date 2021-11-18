using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Memento
{
    public class Memento<T>
    {
        public T State { get; }
        public DateTime DateTime {get;}

        public Memento(T state)
        {
            State = state;
            DateTime = DateTime.Now;
        }
    }
}
