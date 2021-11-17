using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Decorator
{
    public abstract class BaseDecorator : INotification
    {
        private readonly INotification _notification;

        protected BaseDecorator(INotification notification)
        {
            _notification = notification;
        }

        public virtual void Send(string message)
        {
            _notification.Send(message);
            DecoratorSend(message);
        }

        protected abstract void DecoratorSend(string message);
    }
}
