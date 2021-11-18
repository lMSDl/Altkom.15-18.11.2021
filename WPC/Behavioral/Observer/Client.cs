using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Observer
{
    public class Client
    {
        public static void Execute()
        {
            using (var subject = new Subject())
            {
                var observerA = new ObserverA();

                observerA.Unsubscriber = subject.Subscribe(observerA);

                var observerB = new ObserverB();
                observerB.Unsubscriber = subject.Subscribe(observerB);

                subject.SomeBusinessLogic();
                subject.SomeBusinessLogic();
                observerB.Unsubscriber.Dispose();

                subject.SomeBusinessLogic();
                subject.SomeBusinessLogic();
                subject.SomeBusinessLogic();
                observerB.Unsubscriber = subject.Subscribe(observerB);
                subject.SomeBusinessLogic();
            }
        }
    }
}
