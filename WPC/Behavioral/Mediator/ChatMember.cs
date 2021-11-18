using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Mediator
{
    public abstract class ChatMember
    {

        private IChatMediator chat;
        public string Nick { get; }
        public ChatMember(string nick)
        {
            Nick = nick;
        }
        public IChatMediator Chat
        {
            get => chat;
            set
            {
                if (chat != null)
                    chat.Quit(this);
                chat = value;
                if (chat != null)
                    chat.Join(this);
            }
        }
        public virtual void Send(string to, string message)
        {
            Chat.Send(Nick, to, message);
        }
        public virtual void Send(string message)
        {
            Chat.Send(Nick, message);
        }

        public abstract void Receive(string from, string message, bool isPrivate);
    }
}
