﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            return string.Join("; ", base.ToString(), $"{nameof(Username)}: {Username}", $"{nameof(Password)}: {Password}");
        }
    }
}
