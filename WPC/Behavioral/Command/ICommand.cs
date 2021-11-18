using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Command
{
    public interface ICommand
    {
        bool Execute();
        void Undo();
    }
}
