using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.ObjectPool
{
    public class ObjectPool<T>
    {
        private ConcurrentBag<T> _items;

        public ObjectPool(Func<T> func, int counter)
        {
          _items = new ConcurrentBag<T>(Enumerable.Range(0, counter).Select(x => func.Invoke()));
        }

        public virtual T Acquire()
        {
            if (_items.TryTake(out var item))
                return item;
            return default;
        }

        public virtual void Release(T item)
        {
            _items.Add(item);
        }
    }
}
