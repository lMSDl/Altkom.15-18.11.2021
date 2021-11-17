using System.Collections.Generic;

namespace WPC.Structural.Adapter.II
{
    public interface IService
    {
        IEnumerable<Person> GetPeople();
    }
}