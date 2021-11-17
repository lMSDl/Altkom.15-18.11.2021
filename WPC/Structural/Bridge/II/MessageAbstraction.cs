using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Bridge.II
{
    public class MessageAbstraction
    {
        protected IMessageSenderImplementation MessageSender { get; }

        public MessageAbstraction(IMessageSenderImplementation messageSender)
        {
            MessageSender = messageSender;
        }

        public virtual void Send(string message)
        {
            MessageSender.SendMessage(message);
        }
    }
}
