using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Mediator
{
    public class ChatUser : ChatMember
    {
        public ChatUser(string nick) : base(nick)
        {
        }

        public override void Receive(string from, string message, bool isPrivate)
        {
            if (isPrivate)
                Console.WriteLine($"{from} to {Nick}: {message}");
            else
                Console.WriteLine($"{from}: {message}");
        }
    }
}
