using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Flags]
    public enum Roles
    {
        Admin = 1 << 0,
        Create = 1 << 1,
        Read = 1 << 2,
        Update = 1 << 3,
        Delete = 1 << 4
    }
}
