﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusService.Fakers
{
    public class UserFaker : EntityFaker<User>
    {
        public UserFaker()
        {
            RuleFor(x => x.Username, x => x.Internet.UserName());
            RuleFor(x => x.Password, x => x.Internet.Password());
            RuleFor(x => x.Role, x => x.PickRandom<Roles>() | x.PickRandom<Roles>() | x.PickRandom<Roles>());
        }
    }
}
