using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.ChainOfResponsibility.II
{
    public static class Client
    {
        public static void Execute()
        {
            var button = new Button();
            button.Func = parent =>
            {
                if (string.IsNullOrWhiteSpace(((TextBox)parent).InputText))
                {
                    return false;
                }

                ((TextBox)parent).InputText = null;
                Console.WriteLine("Clear");
                return true;
            };

            var textBox = new TextBox();
            textBox.Add(button);

            var frame = new Frame();
            frame.Add(textBox);

            button.Click();
            textBox.InputText = "Test";
            button.Click();
            button.Click();

            textBox.Click();


            Console.WriteLine(button.ClickEventsCounter);
            Console.WriteLine(textBox.ClickEventsCounter);
        }
    }
}
