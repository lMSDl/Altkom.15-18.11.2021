using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Mediator
{
    public class Chat : IChatMediator
    {
        private ICollection<ChatMember> _chatMembers = new List<ChatMember>();

        public void Join(ChatMember member)
        {
            _chatMembers.Add(member);
        }

        public void Quit(ChatMember member)
        {
            _chatMembers.Remove(member);
        }

        public void Send(string from, string to, string message)
        {
            _chatMembers.SingleOrDefault(x => x.Nick == to)?.Receive(from, message, true);
        }

        public void Send(string from, string message)
        {
            var members = _chatMembers.Where(x => x.Nick != from);
            if (_chatMembers.Single(x => x.Nick == from) is EchoChatBot)
            {
                members = members.Where(x => !(x is EchoChatBot));
            }

            foreach (var member in members)
            {
                member.Receive(from, message, false);
            }
        }
    }
}
