using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Mediator
{
    public class Client
    {
        public static void Execute()
        {
            var chat = new Chat();

            ChatMember user = new ChatUser("Paweł");
            ChatMember bot1 = new EchoChatBot("Paul");
            ChatMember bot2 = new EchoChatBot("Ringo");

            user.Chat = chat;
            bot1.Chat = chat;
            bot2.Chat = chat;

            while(true)
            {
                var message = Console.ReadLine().Split("=>");
                if(message.Length == 2)
                {
                    user.Send(message[1].Trim(), message[0].Trim());
                }
                else if(message.Length == 1)
                {
                    user.Send(message[0]);
                }
            }
        }
    }

}
