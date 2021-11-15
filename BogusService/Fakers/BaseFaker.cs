﻿using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusService.Fakers
{
    public abstract class BaseFaker<T> : Faker<T> where T : class
    {
        public BaseFaker() : base("pl")
        {
            StrictMode(true);
        }
    }
}
