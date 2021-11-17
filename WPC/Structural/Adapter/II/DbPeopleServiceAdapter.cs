using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Adapter.II
{
    public class DbPeopleServiceAdapter : IService
    {
        private DbPeopleService service;

        public DbPeopleServiceAdapter(DbPeopleService service)
        {
            this.service = service;
        }

        public IEnumerable<Person> GetPeople()
        {
            return service.Get().Select(x => new Person { Name = $"{x.FirstName} {x.LastName}", Age = DateTime.Now.Year - x.BirthDate.Year });
        }
    }
}
