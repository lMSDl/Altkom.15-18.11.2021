using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.State
{
    public class CoffeeMachine
    {
        private State _state;
        public CoffeeMachine()
        {
            TransitionTo(new HeatingUpState());
        }

        public void MakeLargeCoffee()
        {
            _state.LargeCoffee();
        }

        public void MakeSmallCoffee()
        {
            _state.SmallCoffee();
        }


        public void TransitionTo(State state)
        {
            Console.WriteLine($"CoffeeMachine: Transition to {state.GetType().Name}");
            _state = state;
            state.CoffeeMachine = this;
        }
    }
}
