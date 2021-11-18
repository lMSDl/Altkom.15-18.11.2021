using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.State
{
    public class HeatingUpState : State
    {
        public override void LargeCoffee()
        {
            Console.WriteLine("HeatingUpState: I am heating up!");
        }

        public override void SmallCoffee()
        {
            Console.WriteLine("HeatingUpState: I am heating up!");
        }

        protected override void Init()
        {
            var task = Task.Delay(TimeSpan.FromSeconds(5));
            task.ContinueWith(x => CoffeeMachine.TransitionTo(new IdleState()));
        }
    }
}
