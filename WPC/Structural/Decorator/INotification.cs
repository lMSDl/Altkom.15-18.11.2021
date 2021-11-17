using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Decorator
{
    public interface INotification
    {
        void Send(string message);
    }
}
