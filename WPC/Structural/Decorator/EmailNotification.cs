using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Decorator
{
    public class EmailNotification : BaseDecorator
    {
        public EmailNotification(INotification notification) : base(notification)
        {
        }

        protected override void DecoratorSend(string message)
        {
            Console.WriteLine("Email notification has been send: " + message);
        }
    }
}
