using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Observer
{
    public abstract class Observer<T> : IObserver<T>
    {
        public IDisposable Unsubscriber { get; set; }

        public void OnCompleted()
        {
            Console.WriteLine($"{GetType().Name}: Tansmisja zakończona");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{GetType().Name}: {error.Message}");
        }

        public abstract void OnNext(T value);
    }
}
