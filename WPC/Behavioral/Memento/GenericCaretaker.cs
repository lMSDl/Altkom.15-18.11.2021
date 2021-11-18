using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Memento
{
    public class GenericCaretaker<T> where T : ICloneable, IRestorable<T>
    {
        private List<Memento<T>> _mementos = new List<Memento<T>>();
        private T _originator;

        public GenericCaretaker(T originator)
        {
            _originator = originator;
        }

        public void SaveState()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            _mementos.Add(new Memento<T>((T)_originator.Clone()));
        }
        public void Undo()
        {
            if (_mementos.Count == 0)
            {
                return;
            }

            var memento = _mementos.Last();
            _mementos.Remove(memento);

            Console.WriteLine("Caretaker: Restoring state to: " + memento.DateTime);

            _originator.Restore(memento.State);
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.DateTime);
            }
        }
    }
}
