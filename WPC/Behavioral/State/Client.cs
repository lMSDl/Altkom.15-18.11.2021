using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.State
{
    public class Client
    {
        public static void Execute()
        {
            var coffeeMachine = new CoffeeMachine();

            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(x => coffeeMachine.MakeLargeCoffee());

            Task.Delay(TimeSpan.FromSeconds(7)).ContinueWith(x => coffeeMachine.MakeLargeCoffee());
            Task.Delay(TimeSpan.FromSeconds(9)).ContinueWith(x => coffeeMachine.MakeSmallCoffee());

            Task.Delay(TimeSpan.FromSeconds(12)).ContinueWith(x => coffeeMachine.MakeSmallCoffee());

            Console.ReadLine();

        }
    }
}
