using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPC.Behavioral.Observer
{
    public class Subject : IObservable<int>, IDisposable
    {
        private List<IObserver<int>> _observers = new List<IObserver<int>>();


        public IDisposable Subscribe(IObserver<int> observer)
        {
            _observers.Add(observer);

            return new Ubsubriber(() => _observers.Remove(observer));
        }

        public int Index { get; set; } = 0;

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            Index = new Random().Next(-1, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + Index);

            Notify();
        }
        public void Notify()
        {
            if (Index == -1)
                _observers.ForEach(x => x.OnError(new IndexOutOfRangeException()));
            else
                _observers.ForEach(x => x.OnNext(Index));
        }

        public void Dispose()
        {
            _observers.ForEach(x => x.OnCompleted());
        }

        public class Ubsubriber : IDisposable {

            private Action _action;
            public Ubsubriber(Action action)
            {
                _action = action;
            }

            public void Dispose()
            {
                _action();
            }
        }
    }
}
