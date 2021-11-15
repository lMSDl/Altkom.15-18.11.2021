﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusService.Fakers
{
    public abstract class EntityFaker<T> : BaseFaker<T> where T : Entity
    {
        protected EntityFaker()
        {
            RuleFor(x => x.Id, x => x.UniqueIndex);
        }
    }
}
