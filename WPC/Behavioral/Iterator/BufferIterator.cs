using System.Collections;
using System.Collections.Generic;

namespace WPC.Behavioral.Iterator
{
    public class BufferIterator<T> : IEnumerator<T[]>
    {
        private IEnumerator<T> _enumerator;

        public BufferIterator(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
            Reset();
        }

        public T[] Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _enumerator.Dispose();
            _enumerator = null;
            Current = null;
        }

        public bool MoveNext()
        {
            if (_enumerator.MoveNext())
            {
                Current = new[] { Current[1], _enumerator.Current };
                return true;
            }
            return false;

        }

        public void Reset()
        {
            _enumerator.Reset();
            if (_enumerator.MoveNext())
                Current = new[] { default, _enumerator.Current };
            else
                Current = new T[2];
        }
    }
}