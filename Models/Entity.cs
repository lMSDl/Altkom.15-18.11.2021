using System;

namespace Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }
    }
}
