using System;

namespace WPC.Behavioral.Memento
{
    public interface IRestorable<T> where T : ICloneable, IRestorable<T>
    {
        void Restore(T state);
    }
}