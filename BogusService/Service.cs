using BogusService.Fakers;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BogusService
{
    public class Service<T> where T : Entity
    {
        public ICollection<T> Entities { get; }

        public Service(BaseFaker<T> faker, int numberOfItems)
        {
            Entities = faker.Generate(numberOfItems);
        }
    }
}
