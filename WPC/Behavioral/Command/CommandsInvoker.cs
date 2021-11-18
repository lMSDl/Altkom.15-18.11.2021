using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Command
{
    public class CommandsInvoker
    {

        private static readonly Stack<ICommand> Commands = new Stack<ICommand>();

        private ICommand _command;
        public CommandsInvoker(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            if(_command.Execute())
                Commands.Push(_command);
        }

        public static void Undo()
        {
            if (!Commands.Any())
                return;

            var lastCommand = Commands.Pop();
            lastCommand.Undo();
        }
    }
}
